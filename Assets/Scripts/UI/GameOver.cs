﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreWebText;
    public GameObject scoreBoard;

    private void Start()
    {
        string time = PlayerPrefs.GetString("elapsedTimeInLevel");
        this.timeText.text = "Tiempo \n" + time;
        this.scoreText.text = "Calorías \n" + PlayerPrefs.GetInt("lastScore").ToString();
        this.scoreWebText.text = "";
    }

    public void ShowScoreBoard()
    {
        scoreBoard.GetComponent<ScoreTextUIDisplay>().showData = true;
        scoreBoard.SetActive(true);
    }

    public void RestartGame()
    {
        ShieldCommand.setShieldNotUsed();       
        Points.GetInstance().Set(0);
        SceneManager.LoadSceneAsync(PlayerPrefs.GetString("cameFromScene"));
        //SceneManager.LoadScene(scene)
    }

    public void ExitGame()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        Application.Quit();
    }
}
