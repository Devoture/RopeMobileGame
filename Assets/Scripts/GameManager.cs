using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get { return instance; }}
	public Text scoreText;
	public Text endGameScoreText;
	public Text highscoreText;
	public Text gameHighscoreText;
	public GameObject gameCanvas;
	public GameObject endGameCanvas;
	public GameObject lava;
	public GameObject endGameLava;
	public AdManager am;

	private bool gameOver;
	private static GameManager instance;
	private int score = 0;
	private int highscore;
	private Vector2 lavaStartPos;
	private bool JRCMode;

	private int gameEndLavaZ = -5;

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
		highscore = PlayerPrefs.GetInt("highscore", 0);
		highscoreText.text = "Highscore: " + highscore.ToString();
		gameHighscoreText.text = "Highscore: " + highscore.ToString();
		am = GetComponent<AdManager>();
	}

	public void UpdateScore() {
		if(!JRCMode) {
			score += 10;
			UpdateHUD();
		}
	}

	void UpdateHUD() {
		scoreText.text = "Score: " + score.ToString();
	}

	public void GameOver() {
		if(!JRCMode) {
			gameCanvas.SetActive(false);
			endGameCanvas.SetActive(true);
			endGameLava.SetActive(true);
			endGameScoreText.text = "Score: " + score.ToString();
			gameOver = true;
			am.ShowAd();
			endGameLava.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, gameEndLavaZ);
			if(score > highscore) {
				PlayerPrefs.SetInt("highscore", score);
				PlayerPrefs.Save();
				highscoreText.text = "Highscore: " + score.ToString();
			}
		}
	}

	public void OnEndGameButtonClicked() {
		SceneManager.LoadScene("Main");
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
