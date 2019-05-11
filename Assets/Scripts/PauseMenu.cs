using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Timescale executed!");
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }

    public void OnResumeClicked()
    {
        //Return to game
        ResumeGame();
    }

    public void OnMenuClicked()
    {
        //Goto Menu
        OpenMainMenu();
    }

    public void OnOptionsClicked()
    {
        //Display options
        OpenOptions();
    }

    public void OnExitClicked()
    {
        ExitGame();
    }

    private void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    private void ExitGame()
    {
        Debug.Log("Closed Game!");
        Application.Quit();
    }

    private void OpenOptions()
    {
        //Code to open options menu
        Time.timeScale = 1.0f;
        GetComponent<GameManager>().OpenOptionsMenu();
    }

    private void OpenMainMenu()
    {
        //Code to go to main menu
        Time.timeScale = 1.0f;
        GetComponent<GameManager>().GotoMainMenu();
    }
}
