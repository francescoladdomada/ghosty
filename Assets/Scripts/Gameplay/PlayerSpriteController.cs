using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteController : MonoBehaviour {

	private Vector3 startPosition;
	private float speed = 1.25f;

	private Vector3 moveTo;
	private Vector3 newPosition;

	private bool blinking = false;

	private Color currentColor;
	private Color minAlpha;
	private Color maxAlpha;

	private Color blinkingMinAlpha;
	private Color blinkingMaxAlpha;

	// Use this for initialization
	void Start () {
		startPosition = transform.localPosition;
		MoveToNewPoint ();

		minAlpha = new Color (1f, 1f, 1f, 0.75f);
		maxAlpha = new Color (1f, 1f, 1f, 0.95f);

		blinkingMinAlpha = new Color (1f, 1f, 1f, 0.0f);
		blinkingMaxAlpha = new Color (1f, 1f, 1f, 0.9f);
	}
	
	// Update is called once per frame
	void Update () {
		if ( Vector3.Distance(transform.localPosition, moveTo) > 0.02f ) {			
			//newPosition = Vector3.MoveTowards (transform.localPosition, moveTo, speed * Time.deltaTime);
			newPosition = Vector3.Lerp(transform.localPosition, moveTo, speed * Time.deltaTime);
			transform.localPosition = newPosition;
		} else {
			Invoke ("MoveToNewPoint", 0.1f);
		}

		if (!blinking) {
			currentColor = Color.Lerp(minAlpha, maxAlpha, Mathf.PingPong(Time.time, 2));
		} else {
			currentColor = Color.Lerp(blinkingMinAlpha, blinkingMaxAlpha, Mathf.PingPong(Time.time, 0.1f));
		}
		GetComponent<SpriteRenderer> ().color = currentColor;
		GetComponent<SpriteRenderer>().sortingOrder = (int)transform.position.y*(-1);

	}

	void MoveToNewPoint() {
		moveTo = startPosition;
		moveTo.x += Random.Range (-0.2f, 0.1f);
		moveTo.y += Random.Range (-0.2f, 0.25f);
	}

	public void StartToBlink(float blinkingTime) {
		blinking = true;
		currentColor = blinkingMinAlpha;
		Invoke("StopBlinking", blinkingTime);
	}

	public void StopBlinking() {
		blinking = false;
	}

}
