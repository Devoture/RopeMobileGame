using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawOrbit : MonoBehaviour {
	public float speed = 5.0f;
	public Transform platform;
	public float radius;

	private float timeCounter = 0.0f;
	private Vector3 startPos;

	void Start() {
		startPos = platform.position;
	}

	void Update() {
		timeCounter += Time.deltaTime * speed;
		transform.position = new Vector3(startPos.x + (Mathf.Cos(timeCounter) * radius), startPos.y + (Mathf.Sin(timeCounter) * radius), 0);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			GameManager.Instance.GameOver();
			Destroy(other.gameObject);
		}
	}
}
