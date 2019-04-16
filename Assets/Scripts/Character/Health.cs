using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int InitialHealth = 3;
    [SerializeField] public int MaxHealth = 3;
    [SerializeField] public int MinHealth = 0;

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

    public void Damage(int damage)
    {
        this.CurrentHealth -= damage;

        if (Handlers == null) return;

        foreach(var item in this.Handlers)
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

    public void Start()
    {
        this.CurrentHealth = InitialHealth;
        this.Handlers = new List<HealthListener>();
    }
}
