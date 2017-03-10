using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Formation : MonoBehaviour {
	public float speed = 20f;
	public float width = 10f;
	public float height = 5f;
	public float spawnDelay = 0.1f;
	public static int currentLevel;
	public int enemyCount;
	public GameObject bossPrefab;

	private float direction = -1f;
	private bool isBossLoaded = false;
	
	private int[,] waves = new int[,] {
		{1, 1, 1, 1},
//		{1, 1, 1, 1},
//		{1, 1, 2, 2},
//		{1, 1, 2, 2},
//		{2, 2, 2, 2},
//		{2, 2, 3, 3},
//		{3, 3, 3, 3},
	};

	void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height, 0));
	}

	// Use this for initialization
	void Start () {
		Formation.currentLevel = 0;
		UpdateWaveText();
		SpawnUntilFull();
	}
	
	// Update is called once per frame
	void Update () {
		if (isBossLoaded) {
			return;
		}

		transform.position += new Vector3 (speed * Time.deltaTime * direction, 0, 0);

		if (transform.position.x + (width/2f) > LevelManager.maxX || transform.position.x - (width/2f) < LevelManager.minX) {
			direction *= -1;
		}

		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, LevelManager.minX + (width / 2f), LevelManager.maxX - (width / 2f)), transform.position.y, 0);

		if (enemyCount == 0) {
			Formation.currentLevel++;

			// We have run out of our predefined levels
			if ((Formation.currentLevel >= waves.GetUpperBound(0) + 1)) {
				LoadBoss();
			} else {
				UpdateWaveText();
				SpawnUntilFull();
			}
		}
	}

	void SpawnUntilFull() {
		Transform freePosition = NextFreePosition ();

		// May not have a free position open yet
		if (!(freePosition is Transform)) {
			return;
		}

		enemyCount++;
		int enemyIdx 			= Random.Range (0, 3);
		int enemyNumber 		= (waves [Formation.currentLevel, enemyIdx]) - 1;

		freePosition.GetComponent<EnemyGenerator>().AddEnemy(enemyNumber);

		// Create some delay before the next enemy is spawned
		if (NextFreePosition ()) {
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}

	Transform NextFreePosition() {
		foreach (Transform child in transform) {
			if (child.childCount <= 0) {
				return child;
			}
		}

		return null;
	}

	void UpdateWaveText() {
		int wave = Formation.currentLevel + 1;
		GameObject.Find ("Wave").GetComponent<Text> ().text = "Wave " + wave;
	}

	void LoadBoss() {
		isBossLoaded = true;
		Transform spawnPoint = GameObject.Find ("BossSpawnLocation").GetComponent<Transform>() as Transform;
		GameObject boss = Instantiate(bossPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
	}

	void ShowWinScreen() {
		LevelManager manager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
		manager.LoadLevel("Win");
		return;
	}
}
