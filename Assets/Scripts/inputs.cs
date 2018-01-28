using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputs : MonoBehaviour
{
    public PlanetData myPlanet = new PlanetData(1, 1000, 0.1);
    public VirusData weakVirus = new VirusData(0.1, 0.0);
    public VirusData strongVirus = new VirusData(0.25, 0.5);

    private void Start()
    {
        //myPlanet.AddVirus(weakVirus, 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            myPlanet.Step();
            Debug.Log("Total: " + myPlanet.Population);
            Debug.Log("Infected: " + myPlanet.InfectedPopulation);
            Debug.Log("Dead: " + myPlanet.Deaths);
        }
    }
}

