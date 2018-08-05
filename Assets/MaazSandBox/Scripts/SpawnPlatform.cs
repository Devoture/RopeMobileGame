using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour {
	public int platformDistance = 5;
	public GameObject platformPrefab;

	private int platformCounter = 1;
	private float platformSize = 7.5f;
	
	void Start() {
		spawn();
	}

	void spawn() {
		Vector3 pos = Vector3.zero;
		pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(platformSize, Screen.width - platformSize), (Screen.height * 0.5f), Camera.main.farClipPlane * 0.5f));
		Instantiate(platformPrefab,pos,Quaternion.identity);
		platformCounter ++;
	}
}
