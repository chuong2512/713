using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public Text diamonds;
	public Text lastDiamonds;
	public Text lastDiamondsGameWin;
	public Text level;
	public GameObject pauseMenu;
	public GameObject gameOverMenu;
	public GameObject gameWin;
	public int runOnce = 1;

	// Use this for initialization
	void Start () {

		pauseMenu.SetActive (false);
		gameOverMenu.SetActive (false);
		gameWin.SetActive (false);
		runOnce = 1;

	}
	
	// Update is called once per frame
	void Update () {

		diamonds.text = PlayerPrefs.GetInt ("Diamonds", 0).ToString ();
		lastDiamonds.text = PlayerPrefs.GetInt ("Current Diamond", 0).ToString ();
		lastDiamondsGameWin.text = PlayerPrefs.GetInt ("Current Diamond", 0).ToString ();
		level.text = "LEVEL " + PlayerPrefs.GetInt ("Level", 1).ToString ();

		if (GameObject.FindGameObjectWithTag ("Player") == null) {
			GameOver ();
		} else {
		}
	}

	public void MainMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (0);
	}

	public void Retry()
	{
		Time.timeScale = 1;
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.buildIndex);
	}

	public void Resume()
	{
		Time.timeScale = 1;
		pauseMenu.SetActive (false);
		gameOverMenu.SetActive (false);
		gameWin.SetActive (false);
	}

	public void PauseClicked()
	{
		Time.timeScale = 0;
		pauseMenu.SetActive (true);
		gameOverMenu.SetActive (false);
		gameWin.SetActive (false);
	}

	public void GameOver()
	{
		pauseMenu.SetActive (false);
		gameOverMenu.SetActive (true);
		gameWin.SetActive (false);

		GameObject.Find ("Ad Control").GetComponent<Adcontrol> ().ShowInterstitial ();
	}

	public void GameWon()
	{
		pauseMenu.SetActive (false);
		gameOverMenu.SetActive (false);
		gameWin.SetActive (true);

		GameObject.Find ("Ad Control").GetComponent<Adcontrol> ().ShowInterstitial ();

	}

	public void Level()
	{
		if (runOnce == 1) {
			int levelNo = PlayerPrefs.GetInt ("Level", 1);
			levelNo += 1;
			PlayerPrefs.SetInt ("Level", levelNo);
			runOnce = 0;
		}
	}
}
