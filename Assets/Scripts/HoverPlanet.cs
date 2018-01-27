using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverPlanet : MonoBehaviour
{

	private Quaternion rotation;
	public Text textDisplay;
	private bool isVisible = false;


	// Use this for initialization


	void Start ()
	{
//		textDisplay = GameObject.Find("Text").GetComponent<Text>();
		textDisplay.color = Color.clear;
	}

	// Update is called once per frame
	void Update () {
    Debug.Log(isVisible);
		if (isVisible)
		{
			textDisplay.color = Color.white;
		}
		else
		{
			textDisplay.color = Color.clear;
		}
	}

	void OnMouseOver()
	{
		isVisible = true;
	}

	private void OnMouseExit()
	{
		isVisible = false;
	}


}
