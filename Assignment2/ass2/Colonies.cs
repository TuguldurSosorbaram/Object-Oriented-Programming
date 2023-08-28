using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ass2;
public class Colony
{
    public class TooManytoPerish : Exception { }
    private string name;
    private string species;
    private double population;

    protected Colony(string name, string species, double population)
    {
        this.name = name;
        this.species = species;
        this.population = population;
    }
    //getter
    public string GetName(){ return name; }
    public string GetSpecies(){return species;}
    public double GetPopulation(){return population;}
//setter
    public void SetPopulation(double population){this.population = population;}
}

//Prey
public class Prey : Colony
{
    public Prey(string name, string species, double population) :base(name, species, population){}
    public void getHunted(Predator predator) 
    {
        if (this.IsEnough(predator)) 
        {
            EnoughPrey(predator.GetPopulation());
        }
        else
        {
            this.NotEnoughPrey(predator);
        }
    }
    protected virtual bool IsEnough(Predator predator) { return false; }
    protected virtual void EnoughPrey(double pred) { }
    protected virtual void NotEnoughPrey(Predator predator) { }
    public virtual void Multiply(int round) { }

}
public class Lemming : Prey
{
    public Lemming(string name, string species, double population) : base(name,species,population) { }
    public override void Multiply(int round) 
    {
        if(this.GetPopulation()>200) 
        {
            this.SetPopulation(30);
        }
        else
        {
            if (round % 2 == 0) 
            {
                this.SetPopulation(this.GetPopulation()*2);
            }
        }
    }
    protected override bool IsEnough(Predator predator)
    {
        return 0 < ((this.GetPopulation() / 4) - predator.GetPopulation());
    }
    protected override void EnoughPrey(double pred) 
    {
        this.SetPopulation(this.GetPopulation()-Math.Floor(pred*4));
    }
    protected override void NotEnoughPrey(Predator predator) 
    {
        double diff = predator.GetPopulation() - Math.Floor(this.GetPopulation() / 4);
        this.SetPopulation(this.GetPopulation() - ((predator.GetPopulation() - diff) * 4));
        predator.Perish(diff);
    }
}
public class Hare : Prey
{
    public Hare(string name, string species, double population) : base(name, species, population) { }
    public override void Multiply(int round)
    {
        if (this.GetPopulation() > 100)
        {
            this.SetPopulation(20);
        }
        else
        {
            if (round % 2 == 0)
            {
                this.SetPopulation(this.GetPopulation() + Math.Floor(this.GetPopulation() / 2));
            }
        }
    }
    protected override bool IsEnough(Predator predator)
    {
        return 0 < (this.GetPopulation() / 2) - predator.GetPopulation();
    }
    protected override void EnoughPrey(double pred)
    {
        this.SetPopulation(this.GetPopulation() - (pred * 2));
    }
    protected override void NotEnoughPrey(Predator predator)
    {
        double diff = predator.GetPopulation() - Math.Floor(this.GetPopulation() / 2);
        this.SetPopulation(this.GetPopulation() - ((predator.GetPopulation() - diff) * 2));
        predator.Perish(diff);
    }
}
public class Gopher : Prey
{
    public Gopher(string name, string species, double population) : base(name, species, population) { }
    public override void Multiply(int round)
    {
        if (this.GetPopulation() > 200)
        {
            this.SetPopulation(40);
        }
        else
        {
            if (round % 4 == 0)
            {
                this.SetPopulation(this.GetPopulation() * 2);
            }
        }
    }
    protected override bool IsEnough(Predator predator)
    {
        return 0 < (this.GetPopulation() / 2) - predator.GetPopulation();
    }
    protected override void EnoughPrey(double pred)
    {
        this.SetPopulation(this.GetPopulation() - (pred * 2));
    }
    protected override void NotEnoughPrey(Predator predator)
    {
        double diff = predator.GetPopulation() - Math.Floor(this.GetPopulation() / 2) ;
        this.SetPopulation(this.GetPopulation() - ((predator.GetPopulation() - diff) * 2));
        predator.Perish(diff);
    }
}

//Predator
public class Predator : Colony
{
    public Predator(string name, string species,double population):base(name,species,population){}
    public void Hunt(Prey prey) { prey.getHunted(this); }
    public void Perish(double num) 
    { 
        if(num > this.GetPopulation())
        {
            throw new TooManytoPerish();
        }
        this.SetPopulation(this.GetPopulation() - Math.Floor(num/4)); 
    }
    public virtual void OffSpringProduction(int round) { }
}
public class Owl : Predator
{
    public Owl(string name, string species, double population) : base(name, species, population) { }
    public override void OffSpringProduction(int round)
    {
        if (round % 8 == 0)
        {
            this.SetPopulation(this.GetPopulation() + (Math.Floor(this.GetPopulation() / 4)));
        }
    }
}

public class Fox : Predator
{
    public Fox(string name, string species, double population) : base(name, species, population) { }
    public override void OffSpringProduction(int round)
    {
        if (round % 8 == 0)
        {
            this.SetPopulation(this.GetPopulation() + (Math.Floor(this.GetPopulation() / 4) * 3));
        }
    }
}

public class Wolf : Predator
{
    public Wolf(string name, string species, double population) : base(name, species, population) { }
    public override void OffSpringProduction(int round)
    {
        if (round % 8 == 0)
        {
            this.SetPopulation(this.GetPopulation() + (Math.Floor(this.GetPopulation() / 4) * 2));
        }
    }

}
