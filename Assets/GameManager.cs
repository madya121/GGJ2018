using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

  public GameObject gameOverCanvas;
  public GameObject diseaseCanvas;

  public Animator timeTextAnimator;
  public Text timeText;
  public Text secondTimeText;
  public float timeInSecond;
  public Color textColorBegin, textColorEnd;
  private float secondPassed = 1.0f;

  [HideInInspector]
  public bool isGameOver = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
    timeInSecond -= Time.deltaTime;
    secondPassed -= Time.deltaTime;

    if (!isGameOver && timeInSecond < 0) {
        isGameOver = true;
        diseaseCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    if (isGameOver)
      return;

    int years = (int)((timeInSecond / 60.0f) * 1000.0f);
    if (years < 0)
      years = 0;
    timeText.text = years + " YEARS";
    secondTimeText.text = years + " YEARS";
    Color lerpedColor = Color.Lerp(textColorBegin, textColorEnd, 1.0f - (timeInSecond / 60.0f));
    timeText.color = lerpedColor;
    secondTimeText.color = lerpedColor;
    if (secondPassed < 0.0f) {
      secondPassed = 1.0f;
      timeTextAnimator.SetTrigger("Boom");
    }
	}

  public void OnPlayAgain() {
    // Debug.Log("Play Again");
    Application.LoadLevel(Application.loadedLevel);
  }
}
