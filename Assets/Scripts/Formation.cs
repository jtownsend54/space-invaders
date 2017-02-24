using UnityEngine;
using System.Collections;

public class Formation : MonoBehaviour {
	public float speed = 20f;
	public float width = 10f;
	public float height = 5f;
	private float direction = -1f;
	public int enemyCount;

	void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height, 0));
	}

	// Use this for initialization
	void Start () {
		SpawnEnemies ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (speed * Time.deltaTime * direction, 0, 0);

		if (transform.position.x + (width/2f) > LevelManager.maxX || transform.position.x - (width/2f) < LevelManager.minX) {
			direction *= -1;
		}

		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, LevelManager.minX + (width / 2f), LevelManager.maxX - (width / 2f)), transform.position.y, 0);

		if (enemyCount == 0) {
			Debug.Log ("Formation Destroyed");
			SpawnEnemies();
		}
	}

	void SpawnEnemies() {
		foreach (Transform child in transform) {
			child.GetComponent<EnemyGenerator>().AddEnemy();
		}

		// Reset the enemy count
		enemyCount = transform.childCount;
	}
}
