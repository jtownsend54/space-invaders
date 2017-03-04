using UnityEngine;
using System.Collections;

public class EnemyBomberBehavior : EnemyBehavior {
	public override void shootLaser() {
		GameObject leftLaser = Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y-1, 0), Quaternion.identity) as GameObject;
		leftLaser.rigidbody2D.velocity += new Vector2(-.5f, -5f);

		GameObject rightLaser = Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y-1, 0), Quaternion.identity) as GameObject;
		rightLaser.rigidbody2D.velocity += new Vector2(.5f, -5f);

		AudioSource.PlayClipAtPoint (fire, transform.position);
	}
}
