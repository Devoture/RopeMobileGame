﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get { return instance; }}
	public Text scoreText;
	public Text endGameScoreText;
	public GameObject gameCanvas;
	public GameObject endGameCanvas;
	private bool gameOver;

	private static GameManager instance;
	private int score = 0;

	void Awake() {
		instance = this;
	}

	void Start() {	
		StartCoroutine(UpdateScore());
		gameCanvas.SetActive(true);
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
		gameCanvas.SetActive(false);
		endGameCanvas.SetActive(true);
		endGameScoreText.text = "Score: " + score.ToString();
		gameOver = true;
	}

	public void OnEndGameButtonClicked() {
		SceneManager.LoadScene("JoshScene");
	}
}