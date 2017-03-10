using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public float health = 150f;
	public float fireRate = 0.0f;
	public GameObject laserPrefab;
	public int points = 150;
	public AudioClip fire;
	public AudioClip explode;

	private Formation parentFormation;
	private ScoreKeeper scoreKeeper;

	void Start() {
		parentFormation = transform.parent.transform.parent.GetComponent<Formation>();
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}

	void Update() {
		// Time.deltaTime is the time it took to go through a single frame. This helps to convert our probability to be frame
		// rate independent. The enemy should be shooting .5 shots every second (1 shot every two seconds), but we use a random 
		// value to make this more natural.
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
			parentFormation.enemyCount--;
			scoreKeeper.AddScore(points);
			AudioSource.PlayClipAtPoint (explode, transform.position);
			Destroy (gameObject);
		} else {
			health -= laser.damage;
		}

		Destroy (laser.gameObject);
	}

	public virtual void shootLaser() {
		GameObject laser = Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y-1, 0), Quaternion.identity) as GameObject;
		laser.rigidbody2D.velocity += new Vector2(0, -5f);
		AudioSource.PlayClipAtPoint (fire, transform.position);
	}
}
