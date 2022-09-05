using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorOpener : MonoBehaviour {
	public GameObject leftFloor;
	public GameObject rightFloor;
	public GameObject genericFloor;
	private float rotationSpeed = 0.1f;

	private void Update() {
		if(SceneManager.GetActiveScene().name == "MiniGame") {
			if(PlayerController.winState) {
				if(rightFloor.transform.rotation.eulerAngles.z < 90) {
					leftFloor.transform.Rotate(0, 0, -1 * rotationSpeed);
					rightFloor.transform.Rotate(0, 0, 1 * rotationSpeed);
				}
			}
		} else { // Level 2.
			if(PlayerController.winState) {
				if(genericFloor.transform.rotation.eulerAngles.z <= 6) { // Rounding issue if it's 5 for some reason.
					genericFloor.transform.Rotate(0, 0, -1 * rotationSpeed);
				} else if(genericFloor.transform.position.x > 0) { // Re-center floor.
					genericFloor.transform.Translate(new Vector3(-1 * rotationSpeed, 0, 0));
				} else if(genericFloor.transform.localScale.x < 40) { // Re-scale floor to fit borders.
					genericFloor.transform.localScale += new Vector3(1 * rotationSpeed, 0, 0);
				} else {
					Thread.Sleep(3000); // Super unsafe heeheehee.
					UnityEditor.EditorApplication.isPlaying = false; // Needed to quit the game in the Editor.
					Application.Quit();
				}
			}
		}
	}
}
