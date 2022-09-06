using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * CREATED: 2022-07-26
 * AUTHOR: toydotgame
 * Makes the camera track the player's GameObject and offsets it [in 3D space] by a certain amount.
 */

public class CameraController : MonoBehaviour {
    private Vector3 offset;
    public GameObject player;

    private	void Start() {
        offset = transform.position - player.transform.position;
		Debug.Log("Initialised camera with offset " + offset);
    }

    private void LateUpdate() {
        transform.position = player.transform.position + offset;
    }
}
