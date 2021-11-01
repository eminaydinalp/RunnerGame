using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
	public PlayerController playerController;
	public static PlayerManager instance;
    public GameObject gameOverPanel;
	public TMP_Text coinsText;
	public TMP_Text scoreText;

	public float score;

	private void Start()
	{
		instance = this;
		Time.timeScale = 1f;
		coinsText.text = "Coin : " + PlayerPrefs.GetInt("TotalGems", 0).ToString();
	}
	private void FixedUpdate()
	{
		score += playerController.forwardSpeed * Time.fixedDeltaTime;
		int s = ((int)score);
		scoreText.text = s.ToString();
	}

	public void GameOver()
	{
		Time.timeScale = 0;
		gameOverPanel.SetActive(true);
	}
	public void ReplayButton()
	{
		SceneManager.LoadScene("Game");
	}
	public void QuitGame()
	{
		Application.Quit();
	}
}
