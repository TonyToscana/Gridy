using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject scoreBoard;
    public InputField userName;

    public void Start()
    {
        if (PlayerPrefs.GetString("username") == null || PlayerPrefs.GetString("username").Equals(""))
        {
            userName.text = "Gridy";
            PlayerPrefs.SetString("username", "Gridy");
        }
        else
        {
            userName.text = PlayerPrefs.GetString("username");
        }
    }

    public void OnUsernameChange()
    {
        PlayerPrefs.SetString("username", userName.text);
        PlayerPrefs.Save();
    }

    public void OnStartClicked()
    {
        StartGame();
    }

    public void OnOptionsClicked()
    {
        OpenOptions();
    }

    public void OnRankingClicked()
    {
        ShowRanking();
    }

    public void OnExitCLicked()
    {
        ExitGame();
    }

    void ExitGame()
    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }

    void StartGame()
    {
        SceneManager.LoadScene("LevelOne");
    }

    void OpenOptions()
    {
        optionsMenu.SetActive(true);
        //Code to open the options menu
    }

    void ShowRanking()
    {
        scoreBoard.GetComponent<ScoreTextUIDisplay>().showData = true;
        scoreBoard.SetActive(true);
    }
}
