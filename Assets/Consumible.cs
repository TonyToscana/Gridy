using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumible : MonoBehaviour
{
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.tag.Equals("Player")) return;
        
        Destroy(this.gameObject);
    }
    
    void Update()
    {
        
    }
}
