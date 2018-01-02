using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchControls : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private PlayerController _player;

	public int stepQuantity;
	private bool pressed = false;

	void Start() {
		_player = Object.FindObjectOfType<PlayerController>();
	}

	void Update() {
		if (!pressed)
			return;
		MakeStep ();
	}

	public void MakeStep() {
		_player.MakeStep (stepQuantity);
		pressed = false;
	}

	public void OnPointerDown(PointerEventData eventData) {
		pressed = true;
	}
		
	public void OnPointerUp(PointerEventData eventData) {
		pressed = false;
	}
}
