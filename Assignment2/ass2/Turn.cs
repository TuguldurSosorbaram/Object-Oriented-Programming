using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ass2;

public class Turn
{
    private double initPredatorNums;
    private int tnum;
    public Turn(List<Predator> Predators) 
    {
        tnum = 0;
        foreach (Predator predator in Predators)
        {
            initPredatorNums = initPredatorNums + predator.GetPopulation();
        }
    }

    public int getTnum() { return  tnum; }
    public void Start(ref List<Prey> Preys, ref List<Predator> Predators)
    {
        try
        {
            tnum++;
            foreach (Prey prey in Preys)
            {
                prey.Multiply(tnum);
            }
            foreach (Predator predator in Predators)
            {
                predator.OffSpringProduction(tnum);
                Random random = new Random();
                int indx = random.Next(Preys.Count());
                predator.Hunt(Preys[indx]);
            }
        }catch(Colony.TooManytoPerish)
        {
            Console.WriteLine("Too many number given to perish!");
        }
        
    }
    public bool End(ref List<Predator> Predators)
    {
        double sum = 0;
        foreach(Predator predator in Predators)
        {
            sum = sum + predator.GetPopulation();
        }
        if (sum > initPredatorNums * 2) { return true; }
        else
        {
            int i = 0;
            while (i < Predators.Count())
            {
                if(Predators[i].GetPopulation() > 4)
                {
                    return false;
                }
                i++;
            }
            return true;
        }
    }
}
