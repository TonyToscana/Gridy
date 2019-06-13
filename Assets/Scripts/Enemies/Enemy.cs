using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IEnumerator coroutine;
    public GameManager gameManager;
    private bool inside = false;

    private bool canDoDamage = true;

    private EnemyLogic stats = new EnemyLogic();

    private float lastDamage = 0;
    public int damage = 1;

    private void Update()
    {
        if (lastDamage >= 2)
        {
            lastDamage = 0;
        }
        lastDamage += Time.deltaTime;
    }

    public void Damage(int damage)
    {
        stats.Damage(damage);
        if (stats.GetHealth() <= 0)
            Destroy(this.gameObject);
    }

    public int GetHealth()
    {
        return stats.GetHealth();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && inside == false)
        {
            inside = true;
            lastDamage = 0;
            collision.gameObject.GetComponent<Health>().Damage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inside = false;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && lastDamage >= 2f)
        {
            lastDamage = 0;
            collision.gameObject.GetComponent<Health>().Damage(damage);
        }
    }
}

[System.Serializable]
public class EnemyLogic
{
    [System.Serializable]
    public class EnemyStats
    {
        public int health = 100;
    }

    public EnemyStats stats = new EnemyStats();

    public int GetHealth()
    {
        return this.stats.health;
    }

    public void Damage(int damage)
    {
        stats.health -= damage;
    }
}