using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorOpener : MonoBehaviour {
	public GameObject leftFloor;
	public GameObject rightFloor;
	private float rotationSpeed = 0.001f;

	private void Update() {
		if(PlayerController.winState) {
			for(int i = 0; i < 90; i++) { 
				leftFloor.transform.Rotate(0, 0, -1 * rotationSpeed);
				rightFloor.transform.Rotate(0, 0, 1 * rotationSpeed);
			}
		}
	}
}
