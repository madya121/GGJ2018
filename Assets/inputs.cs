using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputs : MonoBehaviour
{
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
}

