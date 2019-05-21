using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] public string shootableTag = "";

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals(this.shootableTag)) return;

        Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
