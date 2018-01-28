using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiseaseUI : MonoBehaviour, IPointerDownHandler
{
    private AudioSource fxSound;

    [Header("Disease Information")]
    public int diseaseIndex;
    public Sprite diseaseImage;
    public Virus virus;

    public InteractionManager script;

    // Use this for initialization
    void Start()
    {
        virus = GetComponent<Virus>();
        fxSound = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        script.activeDiseaseIndex = diseaseIndex;
        script.diseaseImage = diseaseImage;
        script.virus = virus;
        fxSound.Play ();
    }
}
