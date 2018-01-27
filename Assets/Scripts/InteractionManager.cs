using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour {

  public Sprite sprite;

  [HideInInspector]
  public int activeDiseaseIndex = -1;
  public Sprite diseaseImage;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
    if (activeDiseaseIndex > -1 && Input.GetMouseButtonUp(0)) {
      GameObject obj = GameObject.Find("Helper").GetComponent<Helper>().GetObjectFromMousePosition();
      if (obj) {
      if (activeDiseaseIndex == 0)
          obj.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
        else if (activeDiseaseIndex == 1)
          obj.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
      }

      activeDiseaseIndex = -1;
      GameObject.Find("Helper").GetComponent<Helper>().DettachSpriteFromMousePosition();
    }
    if (activeDiseaseIndex > -1)
      GameObject.Find("Helper").GetComponent<Helper>().AttachSpriteToMousePosition(diseaseImage);
	}
}
