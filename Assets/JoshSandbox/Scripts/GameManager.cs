using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get { return instance; }}
	public Text scoreText;
	private bool gameOver;

	private static GameManager instance;
	private int score = 0;

	void Awake() {
		instance = this;
	}

	void Start() {	
		StartCoroutine(UpdateScore());
	}

	IEnumerator UpdateScore() {
		yield return new WaitForSeconds(1);
		if(!gameOver) {
			score += 10;
			UpdateHUD();
			StartCoroutine(UpdateScore());
		}
	}

	void UpdateHUD() {
		scoreText.text = "Score: " + score.ToString();
	}

	public void GameOver() {
		gameOver = true;
		Debug.Log("Game Over");
	}
}
