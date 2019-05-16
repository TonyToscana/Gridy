using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, HealthListener
{
    public PauseMenu pauseMenu;


    private GameManager manager;
    private GameObject CharacterObject;
    private Health Health;
    private int consumables;
    private bool gameEnded = false;

    private bool HealthListenerSet = false;
    
    private bool playerIsDead = false;

    public void OnDamage(int CurrentHealth, Health health)
    {
    }

    public void OnDeath(int CurrentHealth, Health health)
    {
        if(!playerIsDead)
        {
            playerIsDead = true;
            //change where to get time from
            PlayerPrefs.SetString("elapsedTimeInLevel", FindObjectOfType<LevelManager>().GetTime());
            PlayerPrefs.SetInt("lastScore", Points.GetInstance().Number);
            PlayerPrefs.SetString("cameFromScene", SceneManager.GetActiveScene().name);
            FindObjectOfType<AudioManager>().Stop("MainTheme");
            //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);

            IData webData = new WebData(new Data());

            ScoreData score = new ScoreData
            {
                points = Points.GetInstance().Number,
                time = FindObjectOfType<LevelManager>().GetTime(),
                name = "unknown"
            };

            Debug.Log(webData.Save("name", JsonUtility.ToJson(score, true)));

            SceneManager.LoadSceneAsync("GameOver");
        } 
    }

    private IEnumerator ShowCanvas(Canvas canvas)
    {
        CanvasGroup cv = canvas.GetComponent<CanvasGroup>();

        for (float i = 0; i <= 1.2; i += 0.05f)
        {
            cv.alpha = i;

            yield return new WaitForSeconds(0.009f);
        }

        //Time.timeScale = 0;
    }

    public void OnHeal(int CurrentHealth, Health health)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gameEnded = false;
        this.consumables = FindObjectsOfType<Consumable>().Length;
        this.manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Health == null)
        {
            this.CharacterObject = GameObject.FindGameObjectWithTag("Player");

            if (this.CharacterObject != null)
            {
                this.Health = this.CharacterObject.GetComponent<Health>();
            }
        }
        else if (!HealthListenerSet)
        {
            HealthListenerSet = true;
            Health.SetListener(this);
        }

        if(consumables == 0 && !gameEnded)
        {
            //SceneManager.LoadSceneAsync("LevelWon");
            this.gameEnded = true;
            Debug.Log("YOU FUCKING WONERED");
        }
    }

    public void removeConsumable()
    {
        this.consumables--;
    }

    public void OpenOptionsMenu()
    {
        //code to open options menu
    }

    public void GotoMainMenu()
    {
        //code to go to main menu
    }
}
