using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IHealthState
{
    public int currentLives = 3;
    public int maxLives = 3;
    public int minLives = 0;
    public int CurrentHealth = 100;
    public int maxHealth = 100;
    public int minHealth = 0;
    public int MinHealth = 0;

    public Image HealthBar;
    public IList<HealthListener> Handlers = new List<HealthListener>();

    public IHealthState Vulnerable { get; private set; }
    public IHealthState Invulnerable { get; private set; }
    public IHealthState CurrentState { get; private set; }

    public void Awake()
    {
        this.HealthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Image>();
        this.Invulnerable = new InvulnerableHealth(this);
        this.Vulnerable = new VulnerableHealth(this);

        this.CurrentState = this.Vulnerable;
    }

    public void Start()
    {
    }

    public void SetCurrentHealth(int amount)
    {
        this.CurrentState.SetCurrentHealth(amount);
    }

    public void Damage(int damage)
    {
        this.CurrentState.Damage(damage);
    }

    public void Heal(int heal) 
    {
        this.CurrentState.Heal(heal);
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
            item.OnNewLife(this.currentLives);
        }
    }

    public void ChangeState(IHealthState state)
    {
        this.CurrentState = state;
    }
}
