using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DialogHolder : MonoBehaviour
{

    void Start()
    {
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            DialogManager manager = FindObjectOfType<DialogManager>();

            manager.AddMessage("Hello. I see you are new in the craft.")
                   .AddMessage("This is a dangerous world. I will give you a shild to protext your self for 5 seconds.")
                   .AddMessage("Press ENTER to get the shild.", "Shield")
                   .ShowBox();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
