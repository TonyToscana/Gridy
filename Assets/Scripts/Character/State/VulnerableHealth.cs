using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VulnerableHealth : MonoBehaviour, IHealthState
{

    private Health health;

    public VulnerableHealth(Health health)
    {
        this.health = health;
    }

    public void SetCurrentHealth(int amount)
    {
        if (this.health.CurrentHealth < amount && this.health.Handlers != null)
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
        this.health.CurrentHealth -= damage;

        if (this.health.Handlers == null) return;

        foreach (var item in this.health.Handlers)
        {
            item.OnDamage(this.health.CurrentHealth);
        }

        if (this.health.CurrentHealth <= this.health.MinHealth)
        {
            this.health.CurrentHealth = this.health.maxHealth;

            this.health.currentLives -= 1;


            foreach (var item in this.health.Handlers)
            {
                item.OnLifeConsumed(this.health.CurrentHealth, this.health.currentLives);
            }

            if (this.health.currentLives <= 0)
            {
                foreach (var item in this.health.Handlers)
                {
                    item.OnDeath(this.health.currentLives);
                }
            }
        }

        this.health.HealthBar.fillAmount = (float)this.health.CurrentHealth / 100f;

        
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
