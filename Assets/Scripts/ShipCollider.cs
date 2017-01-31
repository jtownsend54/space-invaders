using UnityEngine;
using System.Collections;

public class ShipCollider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		LaserController laser = collider.gameObject.GetComponent<LaserController> ();

		if (laser) {
			Debug.Log(laser.damage);
		}
	}
}
