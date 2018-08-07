using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public float speed = 2.0f;
	private int direction = 1;

	private Vector3 rightLimit;
	private Vector3 leftLimit;
	private Vector2 movement;
	private Collider2D collider;

	void Awake() {
		rightLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
		leftLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
		collider = GetComponent<Collider2D>();
	}
 
	void Update () {
		if (transform.position.x > rightLimit.x - collider.bounds.size.x * 0.5f) {
			direction = -1;
		} else if (transform.position.x < -leftLimit.x + collider.bounds.size.x * 0.5f) {
			direction = 1;
		}
		movement = Vector2.right * direction * speed * Time.deltaTime; 
		transform.Translate(movement); 
	}
}
