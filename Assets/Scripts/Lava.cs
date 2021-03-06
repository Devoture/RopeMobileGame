﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

	public float speed = 5.0f;
	public float acceleration = 1.0f;
	public float maxSpeed;

	private float startSpeed;

	void Start() {
		startSpeed = speed;
	}

	void Update() {
		if(speed < maxSpeed) {
			speed += Time.deltaTime * acceleration;
		}
		if(speed > maxSpeed) {
			speed = maxSpeed;
		}
		transform.Translate(Vector2.up * speed);
	}

	public void ResetSpeed() {
		speed = startSpeed;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			GameManager.Instance.GameOver();
		}
	}
}
