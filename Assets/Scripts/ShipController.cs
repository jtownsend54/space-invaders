using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
	public float speed = 5.0f;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
		}
	}
}
