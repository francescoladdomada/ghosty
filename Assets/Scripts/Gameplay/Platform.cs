using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public int index;
	public int type;
	public bool hasCoin = false;
	public bool isCoinCollected = false;

	public bool dealDamage = false;

	private bool isPlayerOnIt = false;
	private bool isTrapActivated = false;

	private float standingTimeToActivate = 0.75f;
	private float time = 0f;

	private float trapTimeToToggle = 1.5f;
	private Sprite streetlampOn;
	private Sprite streetlampOff;

	// Use this for initialization
	void Start () {
		streetlampOn = Resources.Load <Sprite> ("Sprites/Platforms/streetlamp_on");
		streetlampOff = Resources.Load <Sprite> ("Sprites/Platforms/streetlamp_off");

	}

	public void SetIndex(int newIndex) {
		index = newIndex;
	}

	public void SetType(int newType) {
		type = newType;
	}

	public void SetHasCoin(bool newHasCoin) {
		hasCoin = newHasCoin;
	}
	
	void Update () {
		switch (type) {
		case 3:
			ManageStandTrapPlatform ();
			break;
		case 4:
			ManageTimeTrapPlatform ();
			break;
		}
	}

	private void ManageStandTrapPlatform() {
		if (isPlayerOnIt && !isTrapActivated) {
			time += Time.deltaTime;

			if (time >= standingTimeToActivate) {
				isTrapActivated = true;
				GetComponent<SpriteRenderer> ().color = Color.black;
				dealDamage = true;
			}
		}
	}

	public void SetPlayerOnIt() {
		isPlayerOnIt = true;
	}


	public void ResetStandTrapPlatform() {
		isPlayerOnIt = false;
		time = 0f;
		isTrapActivated = false;
		dealDamage = false;
		GetComponent<SpriteRenderer> ().color = Color.white;
	}

	private void ManageTimeTrapPlatform() {
		time += Time.deltaTime;
		if (time >= trapTimeToToggle) {
			dealDamage = !dealDamage;
			GameObject streetlampToggleObject = transform.Find ("StreetlampToggle").gameObject;
			if (dealDamage)
				streetlampToggleObject.GetComponent<SpriteRenderer> ().sprite = streetlampOn;
			else
				streetlampToggleObject.GetComponent<SpriteRenderer> ().sprite = streetlampOff;
			time = 0f;
		}
	}

}
