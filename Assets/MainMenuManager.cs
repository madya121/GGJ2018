using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour {

  public Animator animator;
  public GameObject overlay;
  private bool changeScene = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

  public void GoToPlayScene() {
    Debug.Log("asd");
    overlay.SetActive(true);
    if (changeScene)
      return;
    changeScene = true;

    animator.SetTrigger("Change Scene");
  }
}
