using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerSprite : MonoBehaviour {

	private Timer timer;
	private RectTransform sprite;

	private float currentZ = 0;
	private Vector3 currentRotation;
	private float maxRotation = 180f;

	// Use this for initialization
	void Start () {
		timer = Object.FindObjectOfType<Timer> ();
		currentRotation = new Vector3 (0, 0, currentZ);
		sprite = GetComponent<RectTransform> ();

		Scene scene = SceneManager.GetActiveScene();
		if (scene.name == "0") {
		//	GetComponent<Image> ().color = new Color (0, 0, 0, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		currentZ = (timer.timeLeft / timer.timerMax) * maxRotation;
		currentRotation = new Vector3 (0, 0, currentZ);
		sprite.localEulerAngles = currentRotation;
	}

}
