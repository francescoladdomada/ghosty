using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {

	private GameManager gm;

	void Start() {
		gm = Object.FindObjectOfType <GameManager>();
	}

	public void ExitGame() {
		gm.GoToTitleScren ();
	}

}
