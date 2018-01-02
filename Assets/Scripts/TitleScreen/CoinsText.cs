using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsText : MonoBehaviour {

	private GameManager gm;

	void Start () {
		gm = Object.FindObjectOfType<GameManager>();
	}
	
	void Update () {
		GetComponent<Text> ().text = "Coins: " + gm.playerSavedData.coins;
	}
}
