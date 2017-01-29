using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
	public float speed = 5.0f;
	private Vector3 minMaxX;
	private Vector3 minMaxY;
	private float padding = 0.5f;

	void Start() {
		minMaxX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
		minMaxY = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
	}

	// Update is called once per frame
	void Update () {
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
		float xClamp = Mathf.Clamp (transform.position.x, minMaxX.x + padding, minMaxY.x - padding);
		float yClamp = Mathf.Clamp (transform.position.y, minMaxX.y + padding, minMaxY.y - padding);
		transform.position = new Vector3 (xClamp, yClamp, 0);
	}
}
