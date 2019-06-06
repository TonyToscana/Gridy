using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvulnerableHealth : MonoBehaviour, IHealthState
{
    private Health health;

    public InvulnerableHealth(Health health)
    {
        this.health = health;
    }

    //
    // Can not set the health to less amount in this state.
    //
    public void SetCurrentHealth(int amount)
    {
        if (this.health.CurrentHealth >= amount)
        {
            return;
        }

        if (this.health.Handlers != null)
        {
            foreach (var item in this.health.Handlers)
            {
                item.OnHeal(this.health.CurrentHealth);
            }
        }

        this.health.CurrentHealth = amount;
        this.health.HealthBar.fillAmount = (float)this.health.CurrentHealth / 100f;
    }

    public void Damage(int damage)
    {
    }


    public void Heal(int heal)
    {
        if (this.health.CurrentHealth + heal > this.health.maxHealth) return;

        this.SetCurrentHealth(this.health.CurrentHealth + heal);

        if (this.health.Handlers == null) return;

        foreach (var item in this.health.Handlers)
        {
            item.OnHeal(this.health.CurrentHealth);
        }
    }
}
