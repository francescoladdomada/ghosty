using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TitleManager : MonoBehaviour {

	public GameObject _coinsText;
	public GameObject _bestScoreText;

	private GameManager gm;

	// Use this for initialization
	void Start () {
		gm = Object.FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		_coinsText.GetComponent<Text>().text = "Coins: " + gm.playerSavedData.coins;
		_bestScoreText.GetComponent<Text>().text = "Best Score: " + gm.playerSavedData.bestScore;
	}
}
