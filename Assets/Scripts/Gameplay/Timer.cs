using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	private bool isGameRunning = false;
	public float timerMax = 60.0f;
	public float timeLeft = 0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (isGameRunning) {
			timeLeft += Time.deltaTime;
			if (timeLeft >= timerMax) {
				isGameRunning = false;
				GetComponent<GameManager> ().isGameOver = true;
				GetComponent<GameManager> ().UpdateSavedData ();
				// GetComponent<LevelManager> ().GameOver ();
				Instantiate (Resources.Load ("Prefabs/GameOverMenu"), transform.position, Quaternion.identity);
			}
		}
	}

	public void ResetTime() {
		timeLeft = 0f;
	}

	public void StartTimer() {
		isGameRunning = true;
	}

	public void StopTimer() {
		isGameRunning = false;
	}

	public void AddTime() {
		timeLeft -= 15f;
	}

	public void RestartTimer() {
		ResetTime ();
		StartTimer ();
	}
}
