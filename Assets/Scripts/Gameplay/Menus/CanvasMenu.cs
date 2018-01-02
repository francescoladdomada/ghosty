using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// HideMenu ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void HideMenu() {
		foreach(Transform child in transform)
		{
			child.gameObject.SetActive (false);
		}
	}

	public void ShowMenu() {
		foreach(Transform child in transform)
		{
			child.gameObject.SetActive (true);
		}
	}
}
