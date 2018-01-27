using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StatBar : MonoBehaviour {

    public GameObject navy, green, red;
    private Planet planet;

    double radius;

    // Use this for initialization
    void Start () {
        planet = transform.parent.gameObject.GetComponent<Planet>();
        radius = planet.GetComponent<Renderer>().bounds.size.x;
        float multiplier = Math.Max(0.4f, (float)radius / 8);
        navy.GetComponent<LineRenderer>().widthMultiplier = multiplier;
        green.GetComponent<LineRenderer>().widthMultiplier = multiplier;
        red.GetComponent<LineRenderer>().widthMultiplier = multiplier;
        //red = new GameObject();
    }

	// Update is called once per frame
	void Update () {
        float popPercent = (float)(planet.planetData.Population / planet.planetData.MaxPopulation);
        float infPercent = (float)(planet.planetData.InfectedPopulation / planet.planetData.MaxPopulation);
        red.transform.localScale = new Vector3(0, 0, infPercent);
        green.transform.localScale = new Vector3(0, 0, popPercent);

        //double width = red.GetComponent<Renderer>().bounds.size.x;
        if (Input.GetKeyDown("z"))
        {
            Debug.Log("Planet " + this.name + " radius: " + radius);
        }

        
	}
}
