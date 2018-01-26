using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTryOut : MonoBehaviour {

  public Sprite sprite;

  bool onClick = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
    if (Input.GetMouseButtonDown(0))
      onClick = true;
    if (Input.GetMouseButtonUp(0)) {
      onClick = false;
      GameObject.Find("Helper").GetComponent<Helper>().DettachSpriteFromMousePosition();
    }
    if (onClick)
      GameObject.Find("Helper").GetComponent<Helper>().AttachSpriteToMousePosition(sprite);
    /*GameObject.Find("Helper").GetComponent<Helper>().AttachSpriteToMousePosition(sprite);
    if (Input.GetMouseButtonDown(0)) {
      GameObject obj = GameObject.Find("Helper").GetComponent<Helper>().GetObjectFromMousePosition();
      if (obj)
        Debug.Log(obj.tag);
      else
        Debug.Log("None");
    }*/
	}
}
