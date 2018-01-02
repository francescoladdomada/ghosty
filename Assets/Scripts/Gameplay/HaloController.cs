using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaloController : MonoBehaviour {

	private Color currentColor;
	private Color minAlpha;
	private Color maxAlpha;

	// Use this for initialization
	void Start () {
		minAlpha = new Color (1f, 1f, 1f, 0.4f);
		maxAlpha = new Color (1f, 1f, 1f, 0.55f);
	}
	
	// Update is called once per frame
	void Update () {
		currentColor = Color.Lerp(minAlpha, maxAlpha, Mathf.PingPong(Time.time, 3));
		GetComponent<Image> ().color = currentColor;
	}
}
