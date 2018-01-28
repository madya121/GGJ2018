using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatArc : MonoBehaviour {

    private Planet planet;
    public LineRenderer growth, decline;
    public float offset;
    float radius;
    float planetRadius;

    // Use this for initialization  
    void Start () {
        planet = transform.parent.gameObject.GetComponent<Planet>();
        radius = 0.65f;

        planetRadius = planet.GetComponent<SphereCollider>().bounds.size.x;
        growth.GetComponent<LineRenderer>().widthMultiplier = Mathf.Max(1, planetRadius / 12);
        decline.GetComponent<LineRenderer>().widthMultiplier = Mathf.Max(0.25f, planetRadius / 12);
    }

    // Update is called once per frame
    void Update()
    {
        int lastGrowthPercent = -25;  // Percent change from last tick

        if (lastGrowthPercent >= 0)
        {
            lastGrowthPercent = Mathf.Min(lastGrowthPercent, 100);
            growth.GetComponent<Arc>().DrawArc(offset, lastGrowthPercent * 180f / 100, radius);
        }
        else
        {
            lastGrowthPercent = Mathf.Max(lastGrowthPercent, -100);
            decline.GetComponent<Arc>().DrawArc(offset, lastGrowthPercent * 180f / 100, radius);
        }
    }
}


