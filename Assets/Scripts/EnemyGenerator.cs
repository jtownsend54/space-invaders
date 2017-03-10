using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
	public GameObject enemyPrefab;
	public GameObject enemyBomber;
	public GameObject enemyFighter;

	private GameObject[] enemies;

	void Awake() {
		enemies = new GameObject[3]{enemyPrefab, enemyBomber, enemyFighter};
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireSphere (transform.position, 0.5f);
	}

	public void AddEnemy(int enemyNumber) {
		GameObject enemyToAdd 		= enemies[enemyNumber];
		GameObject enemy 			= Instantiate(enemyToAdd, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
		enemy.transform.position 	= transform.position;
		enemy.transform.parent 		= transform;
	}
}
