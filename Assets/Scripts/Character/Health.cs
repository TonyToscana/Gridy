using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int currentLives = 3;
    private int maxLives = 3;
    private int minLives = 0;
    public int CurrentHealth = 100;
    private int maxHealth = 100;
    private int minHealth = 0;
    private int MinHealth = 0;

    private Image HealthBar;
    private IList<HealthListener> Handlers = new List<HealthListener>();
    
    public void Awake()
    {
        this.HealthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Image>();
    }

    public void Start()
    {
    }

    public void SetCurrentHealth(int amount)
    {
        if (this.CurrentHealth < amount && Handlers != null)
        {
            foreach (var item in this.Handlers)
            {
                item.OnHeal(this.CurrentHealth, this);
            }
        }

        this.CurrentHealth = amount;
        this.HealthBar.fillAmount = (float)this.CurrentHealth / 100f;
    }

    public void Damage(int damage)
    {
        if (GameObject.FindObjectsOfType<Power>().Length == 0)
        {

            this.CurrentHealth -= damage;

            if (Handlers == null) return;

            foreach (var item in this.Handlers)
            {
                item.OnDamage(this.CurrentHealth, this);
            }

            if (this.CurrentHealth <= this.MinHealth)
            {
                this.CurrentHealth = this.maxHealth;

                this.currentLives -= 1;


                foreach (var item in this.Handlers)
                {
                    item.OnLifeConsumed(this.CurrentHealth, this.currentLives, this);
                }

                if (this.currentLives <= 0)
                {
                    foreach (var item in this.Handlers)
                    {
                        item.OnDeath(this.currentLives, this);
                    }
                }
            }

            this.HealthBar.fillAmount = (float)this.CurrentHealth / 100f;

        }
    }

    public void Heal(int heal) 
    {
        this.SetCurrentHealth(this.CurrentHealth + heal); 

        if (Handlers == null) return;

        foreach (var item in this.Handlers)
        {
            item.OnHeal(this.CurrentHealth, this);
        }
    }

    public void SetListener(HealthListener listener)
    {
        this.Handlers.Add(listener);
    }

    public void RemoveListener(HealthListener listener)
    {
        this.Handlers.Remove(listener);
    }

    public void AddLife(int amount)
    {
        if (this.currentLives + amount > this.maxLives)
        {
            return;
        }

        this.currentLives += amount;

        if (Handlers == null) return;

        foreach (var item in this.Handlers)
        {
            item.OnNewLife(this.currentLives, this);
        }
    }
}
