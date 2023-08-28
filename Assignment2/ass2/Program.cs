namespace ass2;
using System;
using TextFile;

public class Program
{
    public static void Main(string[] args)
    {
        TextFileReader reader = new("input.txt");
        reader.ReadLine(out string line);
        char[] separators = new char[] { ' ', '\t' };
        string[] nm = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        int n = int.Parse(nm[0]);
        int m = int.Parse(nm[1]);
        List<Prey> Preys = new List<Prey>();
        List<Predator> Predators = new List<Predator>();
        for (int i=0;i<n;i++)
        {
            Prey prey = null ;
            if (reader.ReadLine(out line))
            {
                string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                char sp = char.Parse(tokens[1]);
                double population = double.Parse(tokens[2]);
                switch (sp)
                {
                    case 'l': prey = new Lemming(name,"Lemming",population); break;
                    case 'h': prey = new Hare(name, "Hare", population); break;
                    case 'g': prey = new Gopher(name, "Gopher", population); break;
                }
            }
            Preys.Add(prey);
        }
        for (int i = 0; i < m; i++)
        {
            Predator predator = null;
            if (reader.ReadLine(out line))
            {
                string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                char sp = char.Parse(tokens[1]);
                double population = double.Parse(tokens[2]);
                switch (sp)
                {
                    case 'o': predator = new Owl(name, "Owl", population); break;
                    case 'f': predator = new Fox(name, "Fox", population); break;
                    case 'w': predator = new Wolf(name, "Wolf", population); break;
                }
            }
            Predators.Add(predator);
        }
        for (int i = 0;i<n;i++)
        {
            Console.WriteLine(i + ". " + Preys[i].GetName() + " " + Preys[i].GetSpecies() + " " + Preys[i].GetPopulation());
        }
        for (int i = 0; i < m; i++)
        {
            Console.WriteLine(i + ". " + Predators[i].GetName() + " " + Predators[i].GetSpecies() + " " + Predators[i].GetPopulation());
        }
        Turn turn = new Turn(Predators);
        while (!turn.End(ref Predators))
        {
            turn.Start(ref Preys, ref Predators);
            Console.WriteLine("TURN: " + turn.getTnum());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i + ". " + Preys[i].GetName() + " " + Preys[i].GetSpecies() + " " + Preys[i].GetPopulation());
            }
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine(i + ". " + Predators[i].GetName() + " " + Predators[i].GetSpecies() + " " + Predators[i].GetPopulation());
            }
        }
        









    }
}