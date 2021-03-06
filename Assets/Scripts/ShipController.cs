﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShipController : MonoBehaviour {
	public float speed = 5.0f;
	public float health = 250f;
	public GameObject laserPrefab;
	public AudioClip fire;
	public Text healthText;

	private float padding = 0.5f;

	void Start() {
		healthText = GameObject.Find ("Health").GetComponent<Text> ();
		healthText.text = "Health: " + health.ToString ();
	}

	// Update is called once per frame
	void Update () {
		moveShip ();
		shootLaser ();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		LaserController laser = collider.gameObject.GetComponent<LaserController> ();
		
		if (!laser) {
			return;
		}
		
		if (laser.damage >= health) {
			Destroy (gameObject);
			LevelManager manager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
			manager.LoadLevel("Lose");
		} else {
			health -= laser.damage;
			healthText.text = "Health: " + health.ToString();
		}
		
		Destroy (laser.gameObject);
	}

	private void moveShip() {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += new Vector3(0, speed * Time.deltaTime, 0);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
		}
		
		// Make sure the ship stays within view, with padding so it doesn't get cut off.
		float xClamp = Mathf.Clamp (transform.position.x, LevelManager.minX + padding, LevelManager.maxX - padding);
		float yClamp = Mathf.Clamp (transform.position.y, LevelManager.minY + padding, LevelManager.maxY - padding);
		transform.position = new Vector3 (xClamp, yClamp, 0);
	}

	private void shootLaser() {
		if (Input.GetKeyUp (KeyCode.Space)) {

			GameObject laser = Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y + transform.localScale.y, 0), Quaternion.identity) as GameObject;
			// laser.transform.parent = transform;

			laser.GetComponent<Rigidbody2D>().velocity += new Vector2(0, 5f);

			AudioSource.PlayClipAtPoint(fire, transform.position);
		}
	}
}
