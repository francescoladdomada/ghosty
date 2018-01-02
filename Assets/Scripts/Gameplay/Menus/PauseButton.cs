using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {

	private LevelManager lm;

	void Start() {
		lm = Object.FindObjectOfType <LevelManager>();
	}

	public void TogglePause() {
		lm.TogglePause ();
	}
}
