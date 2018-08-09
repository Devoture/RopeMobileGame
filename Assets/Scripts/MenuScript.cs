using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {


	public void PlayGame(){
		SceneManager.LoadScene("Main");
	}
	public void QuitGame(){
		Application.Quit();
	}
}
