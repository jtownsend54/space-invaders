using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public static float minX;
	public static float maxX;
	public static float minY;
	public static float maxY;

	void Start() {
		Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
		Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
		minX = min.x;
		maxX = max.x;
		minY = min.y;
		maxY = max.y;
	}

	public void LoadLevel(string name) {
		Debug.Log("Load the level: " + name);
		SceneManager.LoadScene (name);
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene(Application.loadedLevel + 1);
	}

	public void QuitRequest() {
		Debug.Log("Quit request.");
		Application.Quit();
	}
}