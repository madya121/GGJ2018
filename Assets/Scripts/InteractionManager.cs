using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{

    public Sprite sprite;

    [HideInInspector]
    public int activeDiseaseIndex = -1;
    public Sprite diseaseImage;
    public Virus virus;

    private AudioSource fxSound;

    public Color red, yellow;

    // Use this for initialization
    void Start()
    {
      fxSound = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeDiseaseIndex > -1 && Input.GetMouseButtonUp(0))
        {
            GameObject obj = GameObject.Find("Helper").GetComponent<Helper>().GetObjectFromMousePosition();
            if (obj)
            {
                Camera.main.GetComponent<cameraController>().Shake();
                if (activeDiseaseIndex == 0)
                {
                    obj.GetComponent<MeshRenderer>().material.SetColor("_Color", red);
                    obj.GetComponent<Planet>().planetData.AddVirus(virus.virusData, 10);
                    Debug.Log("Infected " + obj.name);
                }
                else if (activeDiseaseIndex == 1)
                {
                    obj.GetComponent<MeshRenderer>().material.SetColor("_Color", yellow);
                    obj.GetComponent<Planet>().planetData.AddVirus(virus.virusData, 10);
                    Debug.Log("Infected " + obj.name);
                }

                fxSound.Play ();
            }

            activeDiseaseIndex = -1;
            GameObject.Find("Helper").GetComponent<Helper>().DettachSpriteFromMousePosition();
        }
        if (activeDiseaseIndex > -1)
            GameObject.Find("Helper").GetComponent<Helper>().AttachSpriteToMousePosition(diseaseImage);
    }
}
