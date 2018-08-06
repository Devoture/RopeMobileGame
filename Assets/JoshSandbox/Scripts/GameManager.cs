using System.Collections;
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
		if (instance == null) {
            instance = this;
		} else if (instance != this) {
            Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	void Start() {	
		//StartCoroutine(UpdateScore());
		gameCanvas.SetActive(true);
	}

	// IEnumerator UpdateScore() {
	// 	yield return new WaitForSeconds(1);
	// 	if(!gameOver) {
	// 		score += 10;
	// 		UpdateHUD();
	// 		StartCoroutine(UpdateScore());
	// 	}
	// }

	public void UpdateScore() {
		score += 10;
		UpdateHUD();
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
		ResetGame();
	}

	void ResetGame() {
		gameOver = false;
		scoreText.text = "Score: 0";
		score = 0;
		gameCanvas.SetActive(true);
		endGameCanvas.SetActive(false);
		//StartCoroutine(UpdateScore());
	}
}
