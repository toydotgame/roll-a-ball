using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * CREATED: 2022-07-27
 * AUTHOR: toydotgame
 * Simple animation for the pickups while they idle.
 */

public class PickupRotator : MonoBehaviour {
	private void Update() {
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
