using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStepManager : MonoBehaviour {

	private bool step1_appeared = false;
	private bool step1_disappeared = false;

	private bool step2_appeared = false;
	private bool step2_disappeared = false;

	private bool step3_appeared = false;
	private bool step3_disappeared = false;

	private PlayerController _player;

	public GameObject tutorialStep1;
	public GameObject tutorialStep2;
	public GameObject tutorialStep3;

	// Use this for initialization
	void Start () {
		_player = Object.FindObjectOfType <PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!step1_appeared && (_player.currentIndex == 0 || _player.currentIndex == 1) ) {
			step1_appeared = true;
			tutorialStep1.GetComponent<TutorialStep> ().Show ();
		}

		if (!step1_disappeared && (_player.currentIndex == 5 || _player.currentIndex == 6) ) {
			step1_disappeared = true;
			tutorialStep1.GetComponent<TutorialStep> ().Hide ();
		}

		if (!step2_appeared && (_player.currentIndex == 9 || _player.currentIndex == 10)) {
			step2_appeared = true;
			tutorialStep2.GetComponent<TutorialStep> ().Show ();
		}

		if (!step2_disappeared && (_player.currentIndex == 16 || _player.currentIndex == 17)) {
			step2_disappeared = true;
			tutorialStep2.GetComponent<TutorialStep> ().Hide ();
		}

		if (!step3_appeared && (_player.currentIndex == 22 || _player.currentIndex == 23)) {
			step3_appeared = true;
			tutorialStep3.GetComponent<TutorialStep> ().Show ();
		}

		if (!step3_disappeared && (_player.currentIndex == 25 || _player.currentIndex == 26)) {
			step3_disappeared = true;
			tutorialStep3.GetComponent<TutorialStep> ().Hide ();
		}
	}
}
