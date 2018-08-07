using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour {
	public GameObject[] platformPrefabs;

	private float platformSize = 7.5f;

	void Start() {
		Spawn();
	}

	public void Spawn() {
		int random = Random.Range(0, platformPrefabs.Length);
		Vector3 pos = Vector3.zero;
		pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(platformSize, Screen.width - platformSize), (Screen.height * 0.75f), 10));
		Instantiate(platformPrefabs[random], pos, Quaternion.identity);
	}
}
