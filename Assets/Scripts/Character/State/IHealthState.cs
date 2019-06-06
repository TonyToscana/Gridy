using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthState 
{
    void SetCurrentHealth(int amount);
    void Damage(int damage);
    void Heal(int heal);
}
