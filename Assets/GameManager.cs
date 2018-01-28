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

  public Planet planet1;
  public Planet planet2;
  public Planet planet3;
  public Planet planet4;
  public Planet planet5;
  public Planet planet6;

  private float delay = 3.0f;

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
    if (delay <= 0)
      checkWin();

    delay -= Time.deltaTime;
    if (delay < 0)
      delay = 0;
	}

  public void OnPlayAgain() {
    // Debug.Log("Play Again");
    Application.LoadLevel(Application.loadedLevel);
  }

  void checkWin() {
    int total = planet1.planetData.Population + planet2.planetData.Population + planet3.planetData.Population + planet4.planetData.Population + planet5.planetData.Population + planet6.planetData.Population;
    if (total <= 0)
      Application.LoadLevel("Win Scene");
  }
}
