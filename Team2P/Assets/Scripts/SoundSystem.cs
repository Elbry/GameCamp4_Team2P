using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour {

	public AudioClip walk;
	AudioSource effectSource;

	public void WalkSound() {
		effectSource.clip = walk;
		effectSource.PlayOneShot(effectSource.clip);
	}

	// Use this for initialization
	void Start () {
		effectSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
