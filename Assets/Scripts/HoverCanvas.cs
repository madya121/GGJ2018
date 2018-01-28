using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverCanvas : MonoBehaviour
{

	private Quaternion rotation;
	public Text textObj;
    private Planet planet;
	private int population;
	private int infected;
	private int rateOfChange;
	private int death;


	private String textString;


	void Start()
	{
        planet = transform.parent.gameObject.GetComponent<Planet>();

    }

	void Update()
	{
        population = planet.planetData.Population;
        infected = planet.planetData.InfectedPopulation;
        death = planet.planetData.Deaths;

        textString = "Parasites: " + population +
		             "\n Infected: " + infected +
		             "\n Growth Rate: " + rateOfChange +
		             "\n Eliminated: " + death;


		textObj.text = textString;
	}
	void Awake()
	{
		rotation = transform.rotation;
	}

	private void LateUpdate()
	{
		transform.rotation = rotation;
		//rotation = (0,0,0,0)
	}
}
