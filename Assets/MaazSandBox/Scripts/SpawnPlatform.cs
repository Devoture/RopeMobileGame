using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour {
	public GameObject platformPrefab;

	private float platformSize = 7.5f;
	
	void Start() {
		Spawn();
	}

	public void Spawn() {
		Vector3 pos = Vector3.zero;
		pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(platformSize, Screen.width - platformSize), (Screen.height * 0.75f), Camera.main.farClipPlane * 0.5f));
		Instantiate(platformPrefab, pos, Quaternion.identity);
	}
}
