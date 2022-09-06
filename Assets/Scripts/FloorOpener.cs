using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * CREATED: 2022-09-05
 * AUTHOR: toydotgame
 * Handles animations per level and also deals with exiting the game [from the second level].
 */

public class FloorOpener : MonoBehaviour {
	public GameObject leftFloor;
	public GameObject rightFloor;
	public GameObject genericFloor;
	private float rotationSpeed = 0.1f;
	private bool readyToQuit;

	private void Update() {
		// Level-specific animations:
		switch(SceneManager.GetActiveScene().name) {
			case "Level 1":
				if(!PlayerController.winState) {
					break;
				}
				// Rotate the floor until it is 90° vertical:
				if(rightFloor.transform.rotation.eulerAngles.z < 90) {
					leftFloor.transform.Rotate(0, 0, -1 * rotationSpeed);
					rightFloor.transform.Rotate(0, 0, 1 * rotationSpeed);
				}
				break;
			case "Level 2":
				if(!PlayerController.winState) {
					break;
				}
				// Animate the floor to move from its [starting] tilted position to a flat position, filling the play area up to the walls:
				if(genericFloor.transform.rotation.eulerAngles.z < 6) { // Rounding issue in the Editor won't accept 5.
					genericFloor.transform.Rotate(0, 0, -1 * rotationSpeed);
				} else if(genericFloor.transform.position.x > 0) {
					genericFloor.transform.Translate(new Vector3(-1 * rotationSpeed, 0, 0));
				} else if(genericFloor.transform.localScale.x < 40) {
					genericFloor.transform.localScale += new Vector3(1 * rotationSpeed, 0, 0);
				} else {
					// When all other conditions are met, quit the game:
					Thread childThread = new Thread(new ThreadStart(QuitCountdown));
					childThread.Start();
				}
				break;
		}

		if(readyToQuit) {
			UnityEditor.EditorApplication.isPlaying = false; // Needed to quit the game in the Editor.
			Application.Quit();
		}
	}

	// This is run on a seperate thread:
	public void QuitCountdown() {
		Thread.Sleep(3000);
		readyToQuit = true;
	}
}
