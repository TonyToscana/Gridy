﻿public interface HealthListener 
{
    void OnDeath(int CurrentHealth, Health health);
    void OnHeal(int CurrentHealth, Health health);
    void OnDamage(int CurrentHealth, Health health);
    void OnLifeConsumed(int CurrentHealth, int CurrentLife, Health health);
}
