using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private AudioSource[] audioSources;

	// Use this for initialization
	void Start () {
		audioSources = GetComponents<AudioSource> ();
	}
	
	public void PlayCoinSound() {
		audioSources [0].pitch = 1 + Random.Range (-0.05f, 0.05f);
		audioSources [0].Play ();
	}

	public void PlayPlatformMistakeSound() {
		audioSources [1].pitch = 1 + Random.Range (-0.05f, 0.05f);
		audioSources [1].Play ();
	}

	public void PlayEndLevelSound() {
		audioSources [2].Play ();
	}
}
