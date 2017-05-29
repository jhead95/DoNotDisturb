using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class audio_error : MonoBehaviour {

	AudioSource audio;

	// Use this for initialization
	void Start () {

		audio = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void playAudio_ERROR() {
		audio.Play();


	}

}
