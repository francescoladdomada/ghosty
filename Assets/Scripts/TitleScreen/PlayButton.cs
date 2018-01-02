using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour {

	public void StartGame() {
		GameManager gm = Object.FindObjectOfType<GameManager>();
		gm.StartGame ();
	}
}
