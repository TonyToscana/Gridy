using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
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
        Application.Quit();
    }

    void StartGame()
    {
        SceneManager.LoadScene("LevelOne");
    }

    void OpenOptions()
    {
        //Code to open the options menu
    }

    void ShowRanking()
    {
        //Code to show the ranking
        //SceneManager.LoadScene("Ranking");
    }
}
