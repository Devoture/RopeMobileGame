using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour {
	public GameObject[] platformPrefabs;

	private float platformSize = 7.5f;
	private int prevPlatformIndex;
	private int random;

	void Start() {
		Spawn();
	}

	public void Spawn() {
		random = Random.Range(0, platformPrefabs.Length);
		while(random == prevPlatformIndex) {
			random = Random.Range(0, platformPrefabs.Length);
		}
		prevPlatformIndex = random;
		Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(platformSize, Screen.width - platformSize), (Screen.height * 0.75f), 10));
		Instantiate(platformPrefabs[random], pos, Quaternion.identity);
	}
}
