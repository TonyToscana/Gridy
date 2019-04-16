using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObstacle : MonoBehaviour
{
    [SerializeField] public int DamageDone = 0;

    void OnCollisionEnter2D(Collision2D col)
    {
        Health playerHealth = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Health>();

        if (playerHealth == null) return;

        playerHealth.Damage(DamageDone);
    }

    private void OnTriggerEnter(Collider other)
    {
        Health playerHealth = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Health>();

        if (playerHealth == null) return;

        playerHealth.Damage(DamageDone);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
