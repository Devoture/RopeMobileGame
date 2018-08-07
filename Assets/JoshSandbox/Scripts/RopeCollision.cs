using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCollision : MonoBehaviour {

	public Transform player;
	public RopeScale ropeScale;
	public float cameraYOffset;

	private SpawnPlatform platformScript;
	private Vector2 tmpPos;

	void Start() {
		platformScript = Camera.main.GetComponent<SpawnPlatform>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Platform") {
			player.parent = other.transform;
			ropeScale.ResetRope();
			GameManager.Instance.UpdateScore();
			tmpPos.y = other.transform.position.y + player.GetComponent<BoxCollider2D>().bounds.size.y;
			tmpPos.x = other.transform.position.x;
			player.transform.position = tmpPos;
			Camera.main.transform.position = new Vector3(0, player.position.y - cameraYOffset, Camera.main.transform.position.z);
			other.gameObject.tag = "Untagged";
			platformScript.Spawn();
		}

		if(other.gameObject.tag == "Saw") {
			ropeScale.ResetRope();
		}

		if(other.gameObject.tag == "Jrc") {
			GameManager.Instance.Jrc();
		}
	}
}
