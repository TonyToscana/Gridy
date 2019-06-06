using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ShieldCommand : MonoBehaviour, ICommand
{
    public static bool used;


    private void Start()
    {
        used = false;
    }

    public void Execute(GameObject obj)
    {
        if (!used)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player == null) return;


            PowersObjects powersObjects = player.GetComponent<PowersObjects>();

            if (powersObjects == null || powersObjects.Shield == null) return;

            Vector3 pos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

            GameObject shield = Instantiate(powersObjects.Shield, pos, Quaternion.identity);

            shield.transform.parent = player.transform;

            used = true;

            Health health = FindObjectOfType<Health>();

            if (health != null)
            {
                health.ChangeState(health.Invulnerable);
            }
        }
    }

    internal static void setShieldNotUsed()
    {
        used = false;
    }
}