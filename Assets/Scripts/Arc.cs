using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arc : MonoBehaviour {

    public int segments;
    public float radius;
    LineRenderer arc;

    public void Start()
    {
        DrawArc(-90f, 0f, radius);
    }

    public void Update()
    {
        
    }

    public void DrawArc(float offset, float angle, float radius)
    {
        arc = gameObject.GetComponent<LineRenderer>();
        arc.positionCount = segments + 1;
        arc.useWorldSpace = false;

        float x = 0f, y = 0f, z;
        float startAngle = offset;

        for (int i = 0; i < segments + 1; i++)
        {
            z = Mathf.Sin(Mathf.Deg2Rad * startAngle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * startAngle) * radius;

            arc.SetPosition(i, new Vector3(x, y, z));
            startAngle += angle / segments;
        }
    }
}
