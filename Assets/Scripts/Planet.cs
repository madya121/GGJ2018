using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    public int maxPopulation;
    public int initialPopulation;
    public double birthRate;
    public PlanetData planetData;

    // Use this for initialization
    void Start () {
        planetData = new PlanetData(initialPopulation, maxPopulation, birthRate);
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            planetData.Step();
        }
    }
}
