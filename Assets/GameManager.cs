using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, HealthListener
{
    private GameManager manager;
    private GameObject CharacterObject;
    private Health Health;

    public GameObject gameOverDialog;
    private bool HealthListenerSet = false;


    public void OnDamage(int CurrentHealth, Health health)
    {
    }

    public void OnDeath(int CurrentHealth, Health health)
    {
        Canvas canvas = this.gameOverDialog.GetComponent<Canvas>();
        canvas.enabled = true;
        this.gameOverDialog.SetActive(true);

        StartCoroutine(ShowCanvas(canvas));

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
    }
}
