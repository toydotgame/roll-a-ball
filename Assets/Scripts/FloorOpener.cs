using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorOpener : MonoBehaviour {
	public GameObject leftFloor;
	public GameObject rightFloor;
	private float rotationSpeed = 0.1f;

	private void Update() {
		if(PlayerController.winState) {
			if(rightFloor.transform.rotation.eulerAngles.z < 90) {
				leftFloor.transform.Rotate(0, 0, -1 * rotationSpeed);
				rightFloor.transform.Rotate(0, 0, 1 * rotationSpeed);
			}
		}
	}
}
