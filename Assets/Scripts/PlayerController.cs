using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    public Rigidbody playerRigidbody;
    private float movementX;
    private float movementY;
    private float movementSpeed = 10;

    void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate() {
        playerRigidbody.AddForce(new Vector3(movementX, 0f, movementY) * movementSpeed);
    }
}
