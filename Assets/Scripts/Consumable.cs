using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public int calories = 0;

    private bool pickUpAllowed = false;

    private bool taken = false;

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown("space"))
        {
            taken = true;
            Points.GetInstance().Add(calories);
            FindObjectOfType<GameManager>().removeConsumable();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            pickUpAllowed = false;
        }
    }


}
