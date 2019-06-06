public interface HealthListener 
{
    void OnDeath(int CurrentHealth);
    void OnHeal(int CurrentHealth);
    void OnNewLife(int CurrentLifes);
    void OnDamage(int CurrentHealth);
    void OnLifeConsumed(int CurrentHealth, int CurrentLife);
}
