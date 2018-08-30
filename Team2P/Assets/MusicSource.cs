using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSource : MonoBehaviour {

	AudioSource musicSource;
	public AudioClip music;

	// Use this for initialization
	void Start () {
		musicSource = gameObject.GetComponent<AudioSource>();
		musicSource.clip = music;
		musicSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
