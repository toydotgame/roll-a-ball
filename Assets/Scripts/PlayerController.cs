using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

/*
 * CREATED: 2022-07-26
 * AUTHOR: toydotgame
 * Player and game controller script. Handles player movement, handling the score and win state, and handling triggers.
 */

public class PlayerController : MonoBehaviour {
    public Rigidbody playerRigidbody;
    private float movementX;
    private float movementY;
    private float movementSpeed = 10;
	private int count = 0;
	public TextMeshProUGUI countText;
	public TextMeshProUGUI winText;
	public static bool winState = false;
	private int winCount;

	private void Start() {
		switch(SceneManager.GetActiveScene().name) {
			case "Level 1":
				winCount = 14;
				break;
			case "Level 2":
				winCount = 20;
				break;
			default:
				// A win count of 0 may bring bugs into play regarding when the win text is triggered.
				winCount = 1;
				break;
		}
		
		UpdateCountText();
	}

	private void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate() {
        playerRigidbody.AddForce(new Vector3(movementX, 0f, movementY) * movementSpeed);
    }

	private void OnTriggerEnter(Collider other) {
		switch(other.gameObject.tag) {
			case "Pickup":
				other.gameObject.SetActive(false);
				count++;
				Debug.Log("Collided with Pickup GameObject; score is now " + count + "/" + winCount);
				UpdateCountText();

				if(count >= winCount) {
					winText.gameObject.SetActive(true);
					winState = true;
				}

				break;
			case "LevelLoad": // Currently ambiguous name because there's only two levels.
				// The win state must be cleared on level load because IIRC this variable is stored in DontDestroyOnLoad.
				winState = false;
				SceneManager.LoadScene("Level 2");
				break;
			case "Death":
				if(!winState) {
					SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads the scene.
				}
				break;
			default:
				Debug.Log("Collided with unknown trigger with tag \"" + other.gameObject.tag + "\"");
				break;
		}
	}

	private void UpdateCountText() {
		countText.text = "Score: " + count.ToString() + "/" + winCount;
	}
}
