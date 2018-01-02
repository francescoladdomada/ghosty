using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialImage : MonoBehaviour {

	private Image img;

	private float alpha = 0f;

	private bool fadingIn = false;
	private bool fadingOut = false;

	private float fadeSpeed = 1.5f;
	private bool running = true;

	void Start () {
		img = GetComponent<Image> ();
	}
	
	void Update () {
		if (fadingIn) {
			if (alpha < 1f) {
				alpha += fadeSpeed * Time.deltaTime;
			} else {
				alpha = 1f; 
				running = false;
			}
		} else if( fadingOut ) {
			if (alpha > 0f) {
				alpha -= fadeSpeed * Time.deltaTime;
			} else {
				alpha = 0f; 
				running = false;
			}
		}
		if( running )
			img.color = new Color (1f, 1f, 1f, alpha);
	}

	public void Show() {
		running = true;
		fadingIn = true;
	}

	public void Hide() {
		running = true;
		fadingOut = true;
		fadingIn = false;
	}
}
