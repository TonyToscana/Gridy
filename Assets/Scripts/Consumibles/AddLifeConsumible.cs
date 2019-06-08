using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLifeConsumible : MonoBehaviour
{
    private bool pickUpAllowed = false;
    private bool taken = false;
    public AudioClip CoinPicked;

    private AudioManager audioManager;
    private Collider2D collisionObj;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collisionObj = collision;
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collisionObj = null;
            pickUpAllowed = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown("space") && collisionObj != null)
        {
            taken = true;

            Health health = collisionObj.gameObject.GetComponent<Health>();

            health.AddLife(1);

            FindObjectOfType<AudioManager>().Play("CoinPicked");           
            Destroy(this.gameObject);
        }
    }
}

