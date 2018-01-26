using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour {

  [Header("Mouse Sprite")]
  public SpriteRenderer spriteRenderer;

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
    return pos;
  }

  // Make the sprite following current mouse position
  public void AttachSpriteToMousePosition(Sprite sprite) {
    spriteRenderer.sprite = sprite;

    Vector3 pos = GetCurrentMousePositionInWorld();
    spriteRenderer.transform.position = pos;
  }

  // Detach the sprite from current mouse position
  public void DettachSpriteFromMousePosition() {
    spriteRenderer.sprite = null;
    spriteRenderer.transform.position = Vector3.zero;
  }
}
