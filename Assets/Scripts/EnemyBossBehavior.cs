using UnityEngine;
using System.Collections;

public class EnemyBossBehavior : EnemyBehavior {
	public GameObject leftLaser;
	public GameObject rightLaser;
	public float fireRange;

	private float direction = -1f;

	void Start() {
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}

	public override void shootLaser() {
		GameObject laser = Instantiate(laserPrefab, leftLaser.transform.position, Quaternion.identity) as GameObject;
		laser.rigidbody2D.velocity += new Vector2(Random.Range(-fireRange, fireRange), -5f);

		GameObject laser2 = Instantiate(laserPrefab, rightLaser.transform.position, Quaternion.identity) as GameObject;
		laser2.rigidbody2D.velocity += new Vector2(Random.Range(-fireRange, fireRange), -5f);

		AudioSource.PlayClipAtPoint (fire, transform.position);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		LaserController laser = collider.gameObject.GetComponent<LaserController> ();
		
		if (!laser) {
			return;
		}
		
		if (laser.damage >= health) {
			scoreKeeper.AddScore(points);
			AudioSource.PlayClipAtPoint (explode, transform.position);
			Destroy (gameObject);
			Win();
		} else {
			health -= laser.damage;
		}
		
		Destroy (laser.gameObject);
	}

	void Win() {
		LevelManager manager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
		manager.LoadLevel("Win");
		return;
	}
}
