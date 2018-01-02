using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameDataButton : MonoBehaviour {

	private GameManager gm;

	void Start () {
		gm = Object.FindObjectOfType<GameManager>();
	}

	public void ResetGameData() {
		gm.DeleteGameData ();
	}
}
