using System.Collections;
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
        float timeInSeconds = PlayerPrefs.GetFloat("elapsedTimeInLevel");
        this.timeText.text = "Tiempo \n" + formatTime(timeInSeconds);
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

    private string formatTime(float timeInSeconds)
    {
        int seconds = (int) (timeInSeconds % 60f);
        int minutes = (int) (timeInSeconds / 60f);
        int hours = minutes % 60;
        minutes /= 60;

        return formatNumber(hours) + ":" + formatNumber(minutes) + ":" + formatNumber(seconds);
    }

    private string formatNumber(float number)
    {
        if (number < 10f)
        {
            return "0" + number;
        }
        else return number.ToString();
    }
}
