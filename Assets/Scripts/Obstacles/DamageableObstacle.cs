using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObstacle : MonoBehaviour
{
    [SerializeField] public int DamageDone = 0;
    [SerializeField] public float DamageRate = 2.0f;

    SpriteRenderer spRndrer;
    private float NextDamage;

    void OnCollisionEnter2D(Collision2D col)
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!(Time.time > NextDamage)) return;

        Health playerHealth = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Health>();

        if (col.gameObject.tag != "Player") return;

        NextDamage = Time.time + DamageRate;
        
        playerHealth.Damage(DamageDone);
        
    }

    void Start()
    {

    }

    void Update()
    {

    }
}