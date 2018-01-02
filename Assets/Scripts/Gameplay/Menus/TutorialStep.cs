using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStep : MonoBehaviour {


	void Start () {

	}

	public void Show() {
		transform.Find("Image").GetComponent<TutorialImage>().Show();
		transform.Find("Text").GetComponent<TutorialText>().Show();
	}

	public void Hide() {
		transform.Find("Image").GetComponent<TutorialImage>().Hide();
		transform.Find("Text").GetComponent<TutorialText>().Hide();
	}
}
