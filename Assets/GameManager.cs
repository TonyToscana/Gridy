using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, HealthListener
{
    private GameManager manager;
    private GameObject CharacterObject;
    private Health Health;
<<<<<<< HEAD
    private int consumables;
    private bool gameEnded = false;

=======
    
    public GameObject gameOverDialog;
    private bool HealthListenerSet = false;
    
>>>>>>> 331eaf021aa765432d6921454fd0b3d14450db1c
    private bool playerIsDead = false;

    public void OnDamage(int CurrentHealth, Health health)
    {
    }

    public void OnDeath(int CurrentHealth, Health health)
    {
        //Canvas canvas = this.gameOverDialog.GetComponent<Canvas>();
        //canvas.enabled = true;
        //this.gameOverDialog.SetActive(true);

        //StartCoroutine(ShowCanvas(canvas));
        
        if(!playerIsDead)
        {
            playerIsDead = true;
            PlayerPrefs.SetString("cameFromScene", SceneManager.GetActiveScene().name);
            //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
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

        Time.timeScale = 0;
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
}
