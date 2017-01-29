using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > LevelManager.maxY) {
			Destroy(gameObject);
		}
	}
}
