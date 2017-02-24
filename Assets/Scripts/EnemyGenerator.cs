using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
	public GameObject enemyPrefab;

	void OnDrawGizmos() {
		Gizmos.DrawWireSphere (transform.position, 0.5f);
	}

	// Use this for initialization
//	void Start () {
//		parentFormation = transform.parent.GetComponent<Formation> ();
//	}
	
	// Update is called once per frame
//	void Update () {
//		if (parentFormation.enemyCount == 0) {
//			AddEnemy();
//		}
//	}

	public void AddEnemy() {
		GameObject enemy 			= Instantiate(enemyPrefab, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
		enemy.transform.position 	= transform.position;
		enemy.transform.parent 		= transform;
	}
}
