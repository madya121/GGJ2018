using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Person{
    private HashSet<Virus> viruses;  // Set of unique viruses carried by person
    private PlanetData planet;
    private bool isInfected;
    private static System.Random rng = new System.Random();

    public Person(PlanetData planet)
    {
        // Initialize unique virus set
        viruses = new HashSet<Virus>();
        this.planet = planet;
        planet.Population++;
    }

    public bool IsInfected
    {
        get
        {
            return isInfected;
        }
    }

    public void Reproduce()
    {
        // Calculate probability of new person
        double probability = planet.BirthRate * (1 - (planet.Population / planet.MaxPopulation));
        Debug.Log("Birth Rate: " + planet.BirthRate);
        Debug.Log("Population: " + planet.Population);
        Debug.Log("Max Population: " + planet.MaxPopulation);
        Debug.Log("Reproduce prob: " + probability);

        /*
        // If negative, Delete a random person
        if(probability < 0)
        {
            int rand = rng.Next(0, planet.Population);
            Debug.Log("Random person index: " + rand);
            Debug.Log("Planet population: " + planet.Population);
            Debug.Log("Persons on planet: " + planet.Persons.Count);
            planet.Persons[rand].Delete();
        }
        */

        if(rng.NextDouble() < probability)
        {
            Debug.Log("NextDouble: " + rng.NextDouble());
            // reproduce
            planet.AddPerson();
        }
    }

    public void Kill()
    {
        Delete();
        planet.Deaths++;
    }

    public void Delete()
    {
        // Different from Kill() in that it doesn't register as a death.
        foreach (Virus virus in viruses)
        {
            planet.DecrementVirusInfections(virus);
        }
        planet.RemovePerson(this);
        planet.InfectedPopulation--;
        planet.Population--;
    }

    public void Spread()
    {
        // TODO: Manage iteration through viruses and spread to other Persons
    }

    public bool Contract(Virus newVirus)
    {
        if (this.viruses.Add(newVirus))  // If virus is new to person
        {
            if (!isInfected)  // Person's first infection => +1 to total infected population of planet
            {
                isInfected = true;
                planet.InfectedPopulation++;
            }
            planet.IncrementVirusInfections(newVirus);  // +1 to population of planet infected by this specific virus
            return true;
        }
        return this.viruses.Add(newVirus);
    }

    public void Step()
    {
        //Spread();  // Maybe spread viruses
        Reproduce();  // Maybe reproduce

        double rand = rng.NextDouble();
        if(rand >= Virus.GetEffectiveKillRate(viruses))
        {
            //Kill();  // Probabilistically kill person
        }
    }

    public List<Virus> Viruses
    {
        get
        {
            return new List<Virus>(this.viruses);
        }
    }
}


public class Virus
{
    private double infectionRate;
    private double killRate;

    public Virus(double infectionRate, double killRate)
    {
        this.infectionRate = infectionRate;
        this.killRate = killRate;
    }

    public double InfectionRate
    {
        get
        {
            return infectionRate;
        }
    }

    public double KillRate
    {
        get
        {
            return killRate;
        }
    }

    public static double GetEffectiveKillRate(HashSet<Virus> viruses)
    {
        // TODO: static method to compute the cumulative properties of a set of viruses
        double maxProb = 0;
        foreach(Virus virus in new List<Virus>(viruses))
        {
            if(virus.killRate > maxProb)
            {
                maxProb = virus.killRate;
            }
        }
        return maxProb;
    }
}


public class PlanetData
{
    private List<Person> persons;
    private int population;
    private int maxPopulation;
    private double birthRate;
    private int infectedPopulation;
    private int deaths;
    private Dictionary<Virus, int> virusInfections;  // maps from virus to infected pop
    public static System.Random rng = new System.Random();

    public PlanetData(int initialPopulation, int maxPopulation, double birthRate)
    {
        population = 0;
        this.maxPopulation = maxPopulation;
        this.birthRate = birthRate;
        this.persons = new List<Person>();
        this.virusInfections = new Dictionary<Virus, int>();
        for (int i = 0; i < initialPopulation; i++)
        {
            this.AddPerson();  // Add new people to start with
        }
    }

    public List<Person> Persons
    {
        get
        {
            return persons;
        }
    }

    public void AddPerson(Person person)
    {
        this.persons.Add(person);
    }

    public void AddPerson()
    {
        AddPerson(new Person(this));  // Create a new person and add
    }

    public void RemovePerson(Person person)
    {
        persons.Remove(person);

    }

    public void RemovePersonAtIndex(int index)
    {
        persons.RemoveAt(index);
    }

    public double BirthRate
    {
        get
        {
            return birthRate;
        }
    }

    public double MaxPopulation
    {
        get
        {
            return maxPopulation;
        }
    }

    public int Population
    {
        set
        {
            population = value;
        }

        get
        {
            return population;
        }
    }

    public int InfectedPopulation
    {
        set
        {
            infectedPopulation = value;
        }

        get
        {
            return infectedPopulation;
        }
    }

    public int Deaths
    {
        set
        {
            deaths = value;
        }
        get
        {
            return deaths;
        }
    }
    
    public int GetVirusInfections(Virus virus)
    {
        return virusInfections[virus];
    }

    public void IncrementVirusInfections(Virus virus)
    {
        virusInfections[virus]++;
    }

    public void DecrementVirusInfections(Virus virus)
    {
        virusInfections[virus]--;
    }

    public void AddVirus(Virus newVirus, int initialInfections)
    {
        int randIndex = rng.Next(0, population - initialInfections + 1);
        for (int i = randIndex; i < initialInfections; i++)
        {
            this.persons[i].Contract(newVirus);
        }

        if (!this.virusInfections.ContainsKey(newVirus))
        {
            this.virusInfections.Add(newVirus, initialInfections);
        }
        else
        {
            this.virusInfections[newVirus] += initialInfections;
        }
    }

    public void Step()
    {
        for(int i = 0; i < persons.Count; i++)
        {
            persons[i].Step();
        }

        /*
        // Infect new people with each virus
        foreach(Person person in this.persons)
        {
            foreach (Virus virus in person.Viruses)
            {
                // TODO: Generate unique random integers
                List<int> list = new List<int>();
                List<int> randomIndices = new List<int>();
                for(int i = 0; i < this.population; i++)
                {
                    list.Add(i);
                }

                for(int i = 0; i < (virus.InfectionRate * this.virusInfections[virus]); i++)  // how many new infections do we need?
                {
                    int rand = rng.Next(0, Convert.ToInt32(population));
                    randomIndices.Add(list[rand]);
                    list.RemoveAt(rand);
                }

                if (person.Contract(virus))
                {
                    this.virusInfections[virus]++;
                }
            }
        }
        

        // Population growth due to births
        population += this.birthRate * population * (1 - (population / maxPopulation));

        // Population decline due to deaths
        foreach(Virus virus in virusInfections.Keys)
        {
            double deaths = virus.KillRate * this.virusInfections[virus];
            this.deaths += deaths;
            population -= deaths;
        }
        this.deaths += deaths;
        population -= deaths;

        // calculate new infected population
        infectedPopulation += this.virusInfections.InfectionRate*this.infectedPopulation;
        if (infectedPopulation > population)
        {
            infectedPopulation = this.population;
        }

        // Zero out <1 population
        if (this.population < 1)
        {
            this.population = 0;
            this.infectedPopulation = 0;
        }
        */
        
    }
}

public class PopulationModel : MonoBehaviour
{

}