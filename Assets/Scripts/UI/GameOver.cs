﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{ 
    public void RestartGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("cameFromScene"));
        //SceneManager.LoadScene(scene)
    }

    public void ExitGame()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        Application.Quit();
    }
}
