using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiseaseUI : MonoBehaviour, IPointerDownHandler {

  [Header("Disease Information")]
  public int diseaseIndex;
  public Sprite diseaseImage;

  public InteractionManager script;

	// Use this for initialization
	void Start () {
    
	}

	// Update is called once per frame
	void Update () {

	}

  public void OnPointerDown(PointerEventData eventData) {
    script.activeDiseaseIndex = diseaseIndex;
    script.diseaseImage = diseaseImage;
  }
}
