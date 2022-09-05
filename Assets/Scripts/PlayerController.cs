using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour {
    public Rigidbody playerRigidbody;
    private float movementX;
    private float movementY;
    private float movementSpeed = 10;
	private int count = 0;
	public TextMeshProUGUI countText;
	public TextMeshProUGUI winText;
	public static bool winState = false;
	private int winCount = 14;
	private int level2WinCount = 2;

	private void Start() {
		SetCountText();
		winText.gameObject.SetActive(false);
	}

	void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate() {
        playerRigidbody.AddForce(new Vector3(movementX, 0f, movementY) * movementSpeed);
    }

	void OnTriggerEnter(Collider other) {
		switch(other.gameObject.tag) {
			case "Pickup":
				other.gameObject.SetActive(false);
				count++;
				SetCountText();

				if(SceneManager.GetActiveScene().name == "MiniGame") {
					if(count >= winCount) { // There are 14 pickups in the level, thus ≥ 14 must be collected for a win state to occur.
						winText.gameObject.SetActive(true);
						winState = true;
					}
				} else { // Implies "Level2" is the active scene.
					if(count >= level2WinCount) {
						winText.gameObject.SetActive(true);
						winState = true; // TODO: Redundant AFAIK.
					}
				}

				break;
			case "Level2Load":
				SceneManager.LoadScene("Level2");

				break;
			case "Death":
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				break;
			default:
				Debug.Log("Collided with unknown trigger with tag \"" + other.gameObject.tag + "\"");
				break;
		}
	}

	void SetCountText() {
		countText.text = "Score: " + count.ToString();
		//Debug.Log("Updated countText.text score to " + count.ToString());
	}
}
