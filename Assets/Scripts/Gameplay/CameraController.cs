using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject _player;

	private bool canMove = true;
	private Vector3 currentPosition;
	private Vector3 startPosition;

	private float speedToUse;
	private float normalSpeed = 25f;
	private float mediumSpeed = 35f;
	private float extraSpeed = 100f;

	private float distance;

	private Vector3 moveTo;
	private Vector3 newPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		speedToUse = normalSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove) {
			moveTo = _player.transform.position;
			moveTo.y += 3f;

			distance = Vector3.Distance(moveTo, transform.position);
			if (distance < 7f) {
				speedToUse = normalSpeed;
			} else {
				speedToUse = mediumSpeed;
			}
			if (distance > 15f) {
				speedToUse = extraSpeed;
			}
			newPosition = Vector3.MoveTowards (transform.position, moveTo, speedToUse * Time.deltaTime);
			//Vector3 moveTo = Vector3.Lerp(transform.position, _player.transform.position, Time.time);

			//moveTo.x = startPosition.x;
			//newPosition.y = _player.transform.position.y - 1f;
			newPosition.z = startPosition.z;

			transform.position = newPosition;
		}
	}

	public void StartToMove() {
		canMove = true;
	}

	public void Reset() {
		canMove = false;
		transform.position = startPosition;
	}
}
