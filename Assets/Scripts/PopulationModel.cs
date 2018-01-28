using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VirusData
{
    private double infectionRate;
    private double killRate;

    public VirusData(double infectionRate, double killRate)
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
}

public class PlanetData
{
    private double population;
    private double maxPopulation;
    private double birthRate;
    private double infectedPopulation;
    private double deaths;
    private double lastPopulation;
    private double percentPopulationChange;
    private VirusData virusData;

    public PlanetData(double initialPopulation, double maxPopulation, double birthRate)
    {
        this.population = initialPopulation;
        this.lastPopulation = initialPopulation;
        this.percentPopulationChange = 0;
        this.maxPopulation = maxPopulation;
        this.birthRate = birthRate;
    }

    public int MaxPopulation
    {
        get
        {
            return Convert.ToInt32(maxPopulation);
        }
    }

    public int Population
    {
        get
        {
            return Convert.ToInt32(this.population);
        }
    }

    public int InfectedPopulation
    {
        get
        {
            return Convert.ToInt32(this.infectedPopulation);
        }
    }

    public int Deaths
    {
        get
        {
            return Convert.ToInt32(this.deaths);
        }
    }

    public double LastGrowthPercent
    {
        get
        {
            return percentPopulationChange;
        }
    }

    public void AddVirus(VirusData newVirus, double initialInfections)
    {
        this.virusData = newVirus;
        this.infectedPopulation += initialInfections;
    }

    public void Step()
    {
        // calculate new total population and increment deaths
        population += this.birthRate * population * (1 - (population / maxPopulation));

        if (virusData != null)  // if there is a virus
        {
            double killRate = this.virusData.KillRate;  
            double deaths = killRate * this.infectedPopulation;
            this.deaths += deaths;
            population -= deaths;

            // calculate new infected population
            infectedPopulation += this.virusData.InfectionRate * this.infectedPopulation;
            if (infectedPopulation > population)
            {
                infectedPopulation = this.population;
            }
        }

        // Zero out <1 population
        if (this.population < 1)
        {
            this.population = 0;
            this.infectedPopulation = 0;
        }

        //Debug.Log("Last: " + lastPopulation);
        //Debug.Log("current: " + population);
        //Debug.Log("Change: " + LastGrowthPercent);

        if (lastPopulation > 0)
        {
            double percent = 100 * (population - lastPopulation) / lastPopulation;
            percentPopulationChange = percent;
        }
        lastPopulation = population;
    }
}