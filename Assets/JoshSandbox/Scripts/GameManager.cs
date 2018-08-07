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
	public GameObject lava;

	private bool gameOver;
	private static GameManager instance;
	private int score = 0;
	private Vector2 lavaStartPos;
	private bool JRCMode;

	void Awake() {
		if (instance == null) {
            instance = this;
		} else if (instance != this) {
            Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		lavaStartPos = lava.transform.position;
	}

	void Start() {	
		gameCanvas.SetActive(true);
	}

	public void UpdateScore() {
		score += 10;
		UpdateHUD();
	}

	void UpdateHUD() {
		if(!JRCMode) {
			scoreText.text = "Score: " + score.ToString();
		}
	}

	public void GameOver() {
		if(!JRCMode) {
			gameCanvas.SetActive(false);
			endGameCanvas.SetActive(true);
			endGameScoreText.text = "Score: " + score.ToString();
			gameOver = true;
		}
	}

	public void OnEndGameButtonClicked() {
		SceneManager.LoadScene("JoshScene");
		ResetGame();
	}

	void ResetGame() {
		gameOver = false;
		JRCMode = false;
		scoreText.text = "Score: 0";
		score = 0;
		gameCanvas.SetActive(true);
		endGameCanvas.SetActive(false);
		lava.SetActive(true);
		lava.transform.position = lavaStartPos;
		lava.GetComponent<Lava>().ResetSpeed();
	}

	public void Jrc() {
		lava.SetActive(false);
		scoreText.text = "   JRC: POOP";
		JRCMode = true;
	}
}
