using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour {

  public Image mouseImageUI;

	// Use this for initialization
	void Start () {

	}

  // Get game object from current mouse position
  public GameObject GetObjectFromMousePosition() {
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (Physics.Raycast(ray, out hit, 1000)) {
      GameObject obj = hit.transform.gameObject;
      return obj;
    }

    return null;
  }

  // Convert mouse position into world position
  public Vector3 GetCurrentMousePositionInWorld() {
    Vector3 pos = Input.mousePosition;
    pos.z = 10;
    pos = Camera.main.ScreenToWorldPoint(pos);
    pos.z = 0;
    return pos;
  }

  // Make the sprite following current mouse position
  public void AttachSpriteToMousePosition(Sprite sprite) {
    mouseImageUI.enabled = true;
    mouseImageUI.sprite = sprite;

    mouseImageUI.transform.position = Input.mousePosition;
  }

  // Detach the sprite from current mouse position
  public void DettachSpriteFromMousePosition() {
    mouseImageUI.enabled = false;
    mouseImageUI.sprite = null;
  }
}
