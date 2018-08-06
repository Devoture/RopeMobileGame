using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCollision : MonoBehaviour {

	public Transform player;
	public RopeScale ropeScale;

	private SpawnPlatform platformScript;
	private Vector2 tmpPos;

	void Start() {
		platformScript = Camera.main.GetComponent<SpawnPlatform>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Platform") {
			ropeScale.ResetRope();
			tmpPos.y = other.transform.position.y + player.GetComponent<BoxCollider2D>().bounds.size.y;
			tmpPos.x = other.transform.position.x;
			player.transform.position = tmpPos;
			Camera.main.transform.position = new Vector3(0, player.position.y + 6.32f, Camera.main.transform.position.z);
			platformScript.Spawn();
		}
	}
}
