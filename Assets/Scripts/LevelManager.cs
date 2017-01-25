using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public void LoadLevel(string name) {
		Debug.Log("Load the level: " + name);
//		Brick.breakableCount = 0;
		Application.LoadLevel (name);
	}

	public void LoadNextLevel() {
//		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void QuitRequest() {
		Debug.Log("Quit request.");
		Application.Quit();
	}

//	public void BrickDestroyed() {
//		// Guarding against some case where it could go under 0
//		if (Brick.breakableCount <= 0) {
//			LoadNextLevel();
//		}
//	}
}