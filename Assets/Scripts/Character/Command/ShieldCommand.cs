using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCommand : MonoBehaviour, ICommand
{
    public void Execute()
    {
        Debug.Log("ADS");
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null) return;

        PowersObjects powersObjects = player.GetComponent<PowersObjects>();

        if (powersObjects == null || powersObjects.Shield == null) return;

        Vector3 pos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        GameObject shield = Instantiate(powersObjects.Shield, pos, Quaternion.identity);

        shield.transform.parent = player.transform;
    }
}
