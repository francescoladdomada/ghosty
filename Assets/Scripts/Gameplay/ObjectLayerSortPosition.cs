using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLayerSortPosition : MonoBehaviour {

	void Awake () {
		SetPosition();
	}

	void SetPosition () {
		GetComponent<SpriteRenderer>().sortingOrder = (int)transform.position.y*(-1);;
	}

}
