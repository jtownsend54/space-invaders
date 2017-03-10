using UnityEngine;
using System.Collections;

public class EnemyBossBehavior : EnemyBehavior {
	void Start() {
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}

	public virtual void shootLaser() {
		GameObject laser = Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y-1, 0), Quaternion.identity) as GameObject;
		laser.rigidbody2D.velocity += new Vector2(0, -5f);
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
