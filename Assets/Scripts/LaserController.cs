using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {
	public float damage;

	// Update is called once per frame
	void Update () {
		if (transform.position.y > LevelManager.maxY) {
			Destroy(gameObject);
		}
	}
}
