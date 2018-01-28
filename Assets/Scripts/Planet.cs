using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    public int maxPopulation;
    public int initialPopulation;
    public double birthRate;
    public PlanetData planetData;

    private float timeNeeded = 0.1f;
    private float timer = 0.1f;

    // Use this for initialization
    void Start () {
        planetData = new PlanetData(initialPopulation, maxPopulation, birthRate);
	}

    // Update is called once per frame
    void Update()
    {
      timer -= Time.deltaTime;
        /*if (Input.GetKeyDown("space"))
        {
            planetData.Step();
        }*/
      if (timer < 0) {
        timer = timeNeeded;
        planetData.Step();
      }
    }
}
