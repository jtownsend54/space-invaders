using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	public static int score;
	private Text scoreKeeper;

	// Use this for initialization
	void Start () {
		scoreKeeper = GetComponent<Text>();
		Reset ();
	}
	
	public void AddScore(int points) {
		score += points;
		scoreKeeper.text = score.ToString ();
	}

	void Reset() {
		score = 0;
		scoreKeeper.text = "0";
	}
}
