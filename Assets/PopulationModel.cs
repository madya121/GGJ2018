using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Virus
{
    private double infectionRate;
    private double killRate;

    public Virus(double infectionRate, double killRate)
    {
        this.infectionRate = infectionRate;
        this.killRate = killRate;
    }

    public double getInfectionRate()
    {
        return infectionRate;
    }

    public double getKillRate()
    {
        return killRate;
    }
}

public class Planet
{
    private double population;
    private double maxPopulation;
    private double birthRate;
    private double infectedPopulation;
    private double deaths;
    private Virus virus;

    public Planet(double initialPopulation, double maxPopulation, double birthRate)
    {
        this.population = initialPopulation;
        this.maxPopulation = maxPopulation;
        this.birthRate = birthRate;
    }

    public int getPopulation()
    {
        return Convert.ToInt32(this.population);
    }

    public int getInfectedPopulation()
    {
        return Convert.ToInt32(this.infectedPopulation);
    }

    public int getDeaths()
    {
        return Convert.ToInt32(this.deaths);
    }

    public void addVirus(Virus newVirus, double initialInfections)
    {
        this.virus = newVirus;
        this.infectedPopulation = initialInfections;
    }

    public void step()
    {
        // calculate new total population and increment deaths
        population += this.birthRate * population * (1 - (population / maxPopulation));
        double deaths = this.virus.getKillRate() * this.infectedPopulation;
        this.deaths += deaths;
        population -= deaths;

        // calculate new infected population
        infectedPopulation += this.virus.getInfectionRate() * this.infectedPopulation;
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
    }
}

public class PopulationModel : MonoBehaviour
{
/*
    public Planet myPlanet = new Planet(50, 200, 0.1);
    public Virus weakVirus = new Virus(0.1, 0.05);
    public Virus strongVirus = new Virus(0.25, 0.5);

    private void Start()
    {
        myPlanet.addVirus(weakVirus, 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Total: " + myPlanet.getPopulation());
            Debug.Log("Infected: " + myPlanet.getInfectedPopulation());
            Debug.Log("Dead: " + myPlanet.getDeaths());
            myPlanet.step();
        }
    }
*/
}