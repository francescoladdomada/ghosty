using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchControls : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private PlayerController _player;

	public int stepQuantity;
	private bool pressed = false;
	private Vector2 pointerDownPosition;
	private float deadZone = 75f;

	void Start() {
		_player = Object.FindObjectOfType<PlayerController>();
		pointerDownPosition = Vector2.zero;
	}

	void Update() {

		if (!pressed)
			return;
		//MakeStep (1);
	}

	/*
	public void MakeStep() {
		_player.MakeStep (stepQuantity);
		pressed = false;
	}
	*/
	public void MakeStep(int quantity) {
		_player.MakeStep (quantity);
		pressed = false;
	}

	public void OnPointerDown(PointerEventData eventData) {
		pressed = true;
		pointerDownPosition = eventData.pressPosition;
	}
		
	public void OnPointerUp(PointerEventData eventData) {
		if (eventData.position.y - deadZone > pointerDownPosition.y) {
			MakeStep (2);
		} else {
			MakeStep (1);
		}
		pressed = false;
	}
}
