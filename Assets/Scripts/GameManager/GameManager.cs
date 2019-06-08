using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, HealthListener, IObserver
{
    public PauseMenu pauseMenu;
    [SerializeField] public Image bloodDamagePattern;
    [SerializeField] public Image healHalingPattern;
    [SerializeField] public AudioClip damageAudio;

    private GameManager manager;
    private GameObject CharacterObject;
    private Consumable[] consumablesGame;
    private Health Health;
    private int numberConsumablesGame;
    private bool gameEnded = false;
    private float healingDone = 0;
    private bool damageTaken = false;
    private bool healTaken = false;

    private bool HealthListenerSet = false;

    private bool playerIsDead = false;

    public void OnDamage(int CurrentHealth)
    {
        damageTaken = true;
        GetComponent<AudioSource>().PlayOneShot(damageAudio);
    }

    public void OnDeath(int CurrentHealth)
    {
        if (!playerIsDead)
        {
            playerIsDead = true;
            //change where to get time from
            PlayerPrefs.SetString("elapsedTimeInLevel", FindObjectOfType<LevelManager>().GetTime());
            PlayerPrefs.SetInt("lastScore", Points.GetInstance().Number);
            PlayerPrefs.SetString("cameFromScene", SceneManager.GetActiveScene().name);
            FindObjectOfType<AudioManager>().Stop("MainTheme");
            //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);

            ScoreData score = new ScoreData
            {
                points = Points.GetInstance().Number,
                time = FindObjectOfType<LevelManager>().GetTime(),
                name = PlayerPrefs.GetString("username")
            };

            try
            {
                IData webData = new WebData(new Data());

                webData.Save("name", JsonUtility.ToJson(score, true));
            }
            catch (Exception e)
            {

            }

            object loadData = SaveSystem.Load();

            if (loadData == null)
            {
                SaveSystem.Save(new List<ScoreData>() { score });
            }
            else
            {
                List<ScoreData> scoreDataList = loadData as List<ScoreData>;

                if (scoreDataList == null)
                {
                    scoreDataList = new List<ScoreData>();
                }

                scoreDataList.Add(score);
                scoreDataList = scoreDataList.OrderBy(x => x.points).Reverse().Take(10).ToList();

                SaveSystem.Save(scoreDataList);
            }

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

    public void OnHeal(int CurrentHealth)
    {
        healTaken = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gameEnded = false;
        this.manager = FindObjectOfType<GameManager>();
        FindAndInitializaConsumables();       
        CheckConsumablesAreCreated();
    }

    private void FindAndInitializaConsumables()
    {
        this.consumablesGame = FindObjectsOfType<Consumable>();
        this.numberConsumablesGame = consumablesGame.Length;
    }

    private void CheckConsumablesAreCreated()
    {
        if (numberConsumablesGame == 0)
        {
            StartCoroutine("waitToAttachObserverToConsumables");
        }
        else
        {
            AttachObserverToConsumables();
        }
    }


    IEnumerator waitToAttachObserverToConsumables()
    {            
        yield return new WaitForSeconds(1);
        FindAndInitializaConsumables();
        AttachObserverToConsumables();
    }


    // Update is called once per frame
    void Update()
    {
        

        if (damageTaken)
        {
            bloodDamagePattern.color = new Color(255, 0, 0);
        }
        else
        {
            bloodDamagePattern.color = Color.Lerp(bloodDamagePattern.color, Color.clear, 1f * Time.deltaTime);
        }

        if (healTaken)
        {
            healHalingPattern.color = new Color(0, 255, 0);
        }
        else
        {
            healHalingPattern.color = Color.Lerp(healHalingPattern.color, Color.clear, 1f * Time.deltaTime);
        }

        damageTaken = false;
        healTaken = false;


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

        if (Points.GetInstance().Number >= (int)((healingDone * 100) + 100))
        {
            this.Health.Heal(30);
            healingDone++;
        }


    }

    public void OpenOptionsMenu()
    {
        //code to open options menu
    }

    public void GotoMainMenu()
    {
        //code to go to main menu
    }

    public void OnLifeConsumed(int CurrentHealth, int CurrentLife)
    {
    }

    public void OnNewLife(int CurrentLifes)
    {
    }

    public void Update(ISubject subject)
    {
        this.numberConsumablesGame--;        
        if (numberConsumablesGame == 0 && !gameEnded)
        {
            this.gameEnded = true;
            ShieldCommand.used = false;
            NextLevel();
        }
    }

    private void NextLevel()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "LevelOne":
                SceneManager.LoadSceneAsync("Level2");
                break;
            case "Level2":
                SceneManager.LoadSceneAsync("LevelThree");
                break;
            case "LevelThree":
                SceneManager.LoadSceneAsync("Level4");
                break;
            case "Level4":
                SceneManager.LoadSceneAsync("LevelFive");
                break;
            case "LevelFive":
                SceneManager.LoadSceneAsync("LevelSucceded");
                break;
        }
    }


    private void AttachObserverToConsumables()
    {        
        foreach (var consumable in consumablesGame)
        {
            consumable.Attach(this.manager);
        }
    }
}