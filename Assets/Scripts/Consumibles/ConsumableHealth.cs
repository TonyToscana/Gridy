using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableHealth : Consumable
{
    private int healthRestored = 1;
    override protected void DoAction()
    {
        RestoreHealth();
    }

    private void RestoreHealth()
    {
        FindObjectOfType<Character>()?.gameObject.GetComponent<Health>().Heal(healthRestored);
        //Player.Heal(healthRestored);
    }
}
