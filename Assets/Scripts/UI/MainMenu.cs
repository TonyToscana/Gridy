using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject scoreBoard;

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
        optionsMenu.SetActive(true);
        //Code to open the options menu
    }

    void ShowRanking()
    {
        scoreBoard.GetComponent<ScoreTextUIDisplay>().showData = true;
        scoreBoard.SetActive(true);
    }
}
