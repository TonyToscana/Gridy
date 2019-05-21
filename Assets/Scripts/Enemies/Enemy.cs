using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IEnumerator coroutine;
    public GameManager gameManager;

    private bool canDoDamage = true;
    [System.Serializable]
    public class EnemyStats
    {
        public int health = 100;
    }

    public EnemyStats stats = new EnemyStats();

    private float lastDamage = 0;
    public int damage = 1;

    private void Update()
    {

        //lastDamage += Time.deltaTime;
        coroutine = damageCycle();
    }

    public void Damage(int damage)
    {
        stats.health -= damage;
        if (stats.health <= 0)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && canDoDamage)
        {
            Debug.LogWarning("Damage dealt by alien on enter");
            //collision.gameObject.GetComponent<Health>().Damage(damage);
            StartCoroutine(coroutine);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.LogWarning("TriggerExit2D");
            //StartCoroutine(damageCycle(collision));
            collision.gameObject.GetComponent<Health>().Damage(damage);
            StopCoroutine(coroutine);
        }
    }

    IEnumerator damageCycle()
    {
        while(true)
        {
            Debug.Log("damageCycle!");
            yield return new WaitForSeconds(2);
        }
        //canDoDamage = false;
        //yield return new WaitForSeconds(2);
        //canDoDamage = true;
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && canDoDamage)
        {
            Debug.LogWarning("Damage dealt by alien on stay");
            collision.gameObject.GetComponent<Health>().Damage(damage);
            StartCoroutine(damageCycle());
        }
    }*/
}