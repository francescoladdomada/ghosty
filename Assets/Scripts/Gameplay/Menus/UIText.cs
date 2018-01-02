using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIText : MonoBehaviour {
	
	private Text _text;
	private GameManager 		gm;

	// Use this for initialization
	void Start () {
		_text = GetComponent<Text> ();
		gm = Object.FindObjectOfType <GameManager> ();
	}

	public void Update() {
		_text.text = gm.inGameScore + "";
	}

	public void UpdateText(string str) {
		// _text.text = str;
	}
}
