﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = "Your score: " + ScoreKeeper.score;
	}
}
