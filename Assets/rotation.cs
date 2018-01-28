using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

	public float speed = 0.002f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (0, speed, 0);

	}
}
