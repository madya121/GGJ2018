using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StatBar : MonoBehaviour {

    public GameObject navy, green, red;
    private Planet planet;

	// Use this for initialization
	void Start () {
        planet = transform.parent.gameObject.GetComponent<Planet>();
        //red = new GameObject();
    }
	
	// Update is called once per frame
	void Update () {
        float popPercent = (float)(planet.planetData.Population / planet.planetData.MaxPopulation);
        float infPercent = (float)(planet.planetData.InfectedPopulation / planet.planetData.MaxPopulation);
        red.transform.localScale = new Vector3(0, 0, infPercent);
        green.transform.localScale = new Vector3(0, 0, popPercent);
	}
}
