using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {
    public Rigidbody playerRigidbody;
    private float movementX;
    private float movementY;
    private float movementSpeed = 10;
	private int count = 0;
	public TextMeshProUGUI countText;
	public TextMeshProUGUI winText;

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
		Debug.Log("Collided with trigger with tag \"" + other.gameObject.tag + "\"");

		if(other.gameObject.CompareTag("Pickup")) {
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
		}

		if(count >= 14) { // There are 14 pickups in the level, thus ≥ 14 must be collected for a win state to occur.
			winText.gameObject.SetActive(true);
		}
	}

	void SetCountText() {
		countText.text = "Score: " + count.ToString();
		Debug.Log("Updated countText.text score to " + count.ToString());
	}
}
