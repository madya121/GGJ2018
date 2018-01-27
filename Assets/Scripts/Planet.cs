using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    public PlanetData planetData = new PlanetData(50, 500, 0.1);
    public Virus weakVirus = new Virus(0.1, 0.0);

    // Use this for initialization
    void Start () {
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
