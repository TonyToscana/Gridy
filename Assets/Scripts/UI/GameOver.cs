using System.Collections;
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

    private void Start()
    {
        string time = PlayerPrefs.GetString("elapsedTimeInLevel");
        this.timeText.text = "Tiempo \n" + time;
        this.scoreText.text = "Calorías \n" + PlayerPrefs.GetInt("lastScore").ToString();
        this.scoreWebText.text = this.GetScoresFromWeb();
    }

    private string GetScoresFromWeb()
    {
        IData data = new WebData(new Data());
        string web = data.Load("name");
        ScoreData[] response = JsonHelper.FromJson<ScoreData>(web);
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < response.Length; i++)
        {
            result.Append(response[i].name).Append("\t").Append(response[i].points).Append("\t").Append(response[i].time).Append("\n");
        }

        return result.ToString();
    }

    public void RestartGame()
    {
        ShieldCommand.setShieldNotUsed();       
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
