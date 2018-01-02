using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private GameManager gm;
	private LevelManager lm;
	private SoundManager sm;

	private bool canMove = true;
	public int currentIndex = 0;

	private Vector3 startPosition;
	private PlayerSpriteController playerSpriteController;

	private float blinkingTime = 0.75f;
	private int[] trapsStepped;
	private int trapsSteppedNumber;

	// Use this for initialization
	void Start () {
		gm = Object.FindObjectOfType <GameManager> ();
		lm = Object.FindObjectOfType <LevelManager>();
		sm = Object.FindObjectOfType <SoundManager> ();

		startPosition = transform.position;

		GetComponent<TrailRenderer>().sortingOrder = 4;

		playerSpriteController = transform.Find ("Sprite").gameObject.GetComponent<PlayerSpriteController> ();

		ResetPlayer ();

		trapsStepped = new int[lm.platformsLength];
		for (int i = 0; i < lm.platformsLength; i++) {
			trapsStepped [i] = -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown ("a")) {
			MakeStep (1);
		}
		if (Input.GetKeyDown ("s")) {
			MakeStep (2);
		}

		if (canMove) {
			CheckPlatform ();
		}

		if (Input.GetKeyDown ("p")) {
			gm.LoadNextLevel();
		}


		//if (Input.GetKeyDown ("r")) {
		//	lm.ResetLevel ();
		//}
	}

	public void CheckPlatform() {

		Platform platform = lm.GetPlatformByIndex (currentIndex);

		transform.position = platform.transform.position;

		if (platform.hasCoin && !platform.isCoinCollected) {
			platform.isCoinCollected = true;
			gm.inGameCoins += 1;
			// sm.PlayCoinSound ();
			platform.transform.GetChild (0).gameObject.GetComponent<Coin> ().Delete ();
		}
		lm.UpdateUITexts ();

		if (platform.dealDamage)
			SlowDownPlayer ();

		// level completed
		if (platform.type == 2) {
			canMove = false;
			gm.LoadNextLevel();
		}

		// stand-trap platform
		if (platform.type == 3) {
			platform.SetPlayerOnIt ();
			if( !AlreadyStepped(platform.index) ) {
				trapsStepped [trapsSteppedNumber] = platform.index;
				trapsSteppedNumber++;
			}

		}

	}

	public void MakeStep(int quantity) {
		
		if ( lm.IsGameRunning () && canMove ) {
			currentIndex += quantity;
			gm.inGameScore += quantity;

			Platform platform = lm.GetPlatformByIndex (currentIndex);
			if (platform.transform.position.x < transform.position.x)
				transform.localScale = new Vector3 (-1, 1, 1);
			else
				transform.localScale = new Vector3 (1, 1, 1);

			Instantiate (Resources.Load ("Prefabs/FadingParticle"), transform.position, Quaternion.identity);
			Instantiate (Resources.Load ("Prefabs/FadingParticle"), platform.transform.position, Quaternion.identity);
			//CheckPlatform ();
		}
	}

	public void ResetPlayer() {
		canMove = true;

		currentIndex = 0;
		transform.position = startPosition;
	}

	public void SlowDownPlayer() {
		canMove = false;
		sm.PlayPlatformMistakeSound ();
		playerSpriteController.StartToBlink ( blinkingTime );
		Invoke ("StartToMoveAgain", blinkingTime);
	}

	public void StartToMoveAgain() {
		canMove = true;
		gm.inGameScore -= currentIndex;

		ResetPlayer ();
		ResetTrapsStatus ();
	}

	private void ResetTrapsStatus() {
		for (int i = 0; i < lm.platformsLength; i++) {
			if (trapsStepped [i] != -1) {
				Platform platform = lm.GetPlatformByIndex (trapsStepped [i]);
				platform.ResetStandTrapPlatform ();
			}
			trapsStepped [i] = -1;
		}
		trapsSteppedNumber = 0;
	}

	private bool AlreadyStepped(int platformIndex) {
		for (int i = 0; i < lm.platformsLength; i++) {
			if (trapsStepped [i] == platformIndex)
				return true;
		}
		return false;
	}
}
