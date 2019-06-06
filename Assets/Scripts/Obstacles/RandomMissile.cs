using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMissile : MonoBehaviour
{
    [SerializeField] public string shootableTag = "";

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals(this.shootableTag)) return;

        Health health = collision.GetComponent<Health>();

        health.Damage(30);

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
