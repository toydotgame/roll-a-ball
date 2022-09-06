using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Vector3 offset;
    public GameObject player;

    private	void Start() {
        offset = transform.position - player.transform.position;
		Debug.Log("Initialised camera with offset " + offset + ".");
    }

    private void LateUpdate() {
        transform.position = player.transform.position + offset;
    }
}
