using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public int calories = 0;

    private bool taken = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown("space") && !taken)
        {
            taken = true;
            Points.GetInstance().Add(calories);
            FindObjectOfType<GameManager>().removeConsumable();
            Destroy(this.gameObject);
        }
    }


}
