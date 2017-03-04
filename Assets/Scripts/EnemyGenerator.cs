using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
	public GameObject enemyPrefab;
	public GameObject enemyBomber;
	public GameObject enemyFighter;

	void OnDrawGizmos() {
		Gizmos.DrawWireSphere (transform.position, 0.5f);
	}

	public void AddEnemy() {
		GameObject enemyToAdd = enemyPrefab;

		if (ScoreKeeper.score > 1000) {
			enemyToAdd = enemyBomber;
		}

		if (ScoreKeeper.score > 3000) {
			enemyToAdd = enemyFighter;
		}

		GameObject enemy 			= Instantiate(enemyToAdd, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
		enemy.transform.position 	= transform.position;
		enemy.transform.parent 		= transform;
	}
}
