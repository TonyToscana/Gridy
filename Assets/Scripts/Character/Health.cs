using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentLives = 3;
    private int maxLives = 3;
    private int minLives = 0;
    public int currentHealth = 100;
    private int maxHealth = 100;
    private int minHealth = 0;
    private int MinHealth = 0;


    private IList<HealthListener> Handlers;

    private int _currentHealth;
    public int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }

        private set
        {
            _currentHealth = value;
        }
    }

    public void Start()
    {
        this.CurrentHealth = 3;
        this.Handlers = new List<HealthListener>();
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
                foreach (var item in this.Handlers)
                {
                    item.OnDeath(this.CurrentHealth, this);
                }
            }
        }
    }

    public void Heal(int heal) 
    {
        this.CurrentHealth += heal;

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

}
