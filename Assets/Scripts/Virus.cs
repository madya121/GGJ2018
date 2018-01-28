using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour {

    public float infectionRate, killRate;
    public VirusData virusData;


	// Use this for initialization
	void Start () {
        virusData = new VirusData(infectionRate, killRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
