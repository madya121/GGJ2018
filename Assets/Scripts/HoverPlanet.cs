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
    public Animator animator;

    // Use this for initialization
    void Start()
    {
        //		textDisplay = GameObject.Find("Text").GetComponent<Text>();
        //textDisplay.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        if (isVisible)
        {
            // textDisplay.color = Color.white;
        }
        else
        {
            // textDisplay.color = Color.clear;

        }
    }

    void OnMouseOver()
    {
        if (isVisible)
            return;
        animator.SetTrigger("Open");
        isVisible = true;
    }

    private void OnMouseExit()
    {
        if (!isVisible)
            return;
        animator.SetTrigger("Close");
        isVisible = false;
    }
}
