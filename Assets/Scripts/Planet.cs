using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    public int maxPopulation;
    public int initialPopulation;
    public double birthRate;
    public PlanetData planetData;
    private Virus weakVirus = new Virus(0.1, 0.0);

    // Use this for initialization
    void Start () {
        planetData = new PlanetData(initialPopulation, maxPopulation, birthRate);
        planetData.AddVirus(weakVirus, 10);
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
