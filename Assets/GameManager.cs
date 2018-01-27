using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

  public GameObject gameOverCanvas;
  public GameObject diseaseCanvas;

  public bool isGameOver = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
    if (!isGameOver && Input.GetKeyDown(KeyCode.Escape)) {
      isGameOver = true;
      diseaseCanvas.SetActive(false);
      gameOverCanvas.SetActive(true);
    }
	}

  public void OnPlayAgain() {
    // Debug.Log("Play Again");
    Application.LoadLevel(Application.loadedLevel);
  }
}
