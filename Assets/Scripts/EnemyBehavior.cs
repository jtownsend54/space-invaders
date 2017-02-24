using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public float health = 150f;
	public float fireRate = 0.5f;
	public GameObject laserPrefab;

	void Update() {
		// Time.deltaTime is the time it took to go through a single frame. This helps to convert our probability to be frame
		// rate independent. The enemy should be shooting .5 shots every second (1 shot every two seconds), but we use a random 
		// value to make this more natural.
		Debug.Log (Random.value);
		Debug.Log (fireRate * Time.deltaTime);
		if (Random.value <= fireRate * Time.deltaTime) {
			shootLaser ();
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		LaserController laser = collider.gameObject.GetComponent<LaserController> ();

		if (!laser) {
			return;
		}

		if (laser.damage >= health) {
			Destroy (gameObject);
		} else {
			health -= laser.damage;
		}

		Destroy (laser.gameObject);
	}

	void shootLaser() {
		GameObject laser = Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y-1, 0), Quaternion.identity) as GameObject;
		laser.rigidbody2D.velocity += new Vector2(0, -5f);
	}
}
