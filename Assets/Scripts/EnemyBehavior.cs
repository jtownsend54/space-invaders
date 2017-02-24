using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public float health = 150f;
	public float fireRate = 10;
	public GameObject laserPrefab;

	void Update() {
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

		Destroy (laser);
	}

	void shootLaser() {
		GameObject laser = Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y-1, 0), Quaternion.identity) as GameObject;
		laser.rigidbody2D.velocity += new Vector2(0, -5f);
	}
}
