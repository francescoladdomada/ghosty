using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour {

//	private LevelManager lm;
	private GameManager gm;

	void Start() {
//		lm = Object.FindObjectOfType <LevelManager>();
		gm = Object.FindObjectOfType <GameManager>();
	}

	public void RestartGame() {
		gm.StartGame ();
		//lm.ResetLevel ();
	}

	public void RestartGameFromGameOverMenu() {
		gm.StartGame ();
	}
}
