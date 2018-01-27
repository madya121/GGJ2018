using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverCanvas : MonoBehaviour
{

	private Quaternion rotation;
	public Text textObj;

	public int population;
	public int infected;
	public int rateOfChange;
	public int death;


	private String textString;


	void Start()
	{

	}

	void Update()
	{
		textString = "Population: " + population +
		             "\n Infected: " + infected +
		             "\n Rate: " + rateOfChange +
		             "\n Death: " + death;


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
