﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        string time = PlayerPrefs.GetString("elapsedTimeInLevel");
        this.timeText.text = "Tiempo \n" + time;
        this.scoreText.text = "Calorías \n" + PlayerPrefs.GetInt("lastScore").ToString();
    }

    public void RestartGame()
    {
        Points.GetInstance().Set(0);
        SceneManager.LoadScene(PlayerPrefs.GetString("cameFromScene"));
        //SceneManager.LoadScene(scene)
    }

    public void ExitGame()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        Application.Quit();
    }
}
