using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioScript : MonoBehaviour {
	AudioSource fxSound;
	public AudioClip backMusic;
	// Use this for initialization
	void Start () {
		fxSound = GetComponent<AudioSource> ();
		fxSound.Play ();
	}

	// Update is called once per frame
	void Update () {

	}

}
