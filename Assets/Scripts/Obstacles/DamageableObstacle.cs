using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObstacle : MonoBehaviour
{
    [SerializeField] public int DamageDone = 0;

    SpriteRenderer spRndrer;

    void OnCollisionEnter2D(Collision2D col)
    {
        Health playerHealth = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Health>();

        if (col.gameObject.tag != "Player") return;

        playerHealth.Damage(DamageDone);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Health playerHealth = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Health>();

        if (collision.gameObject.tag != "Player") return;

        playerHealth.Damage(DamageDone);

        //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 0.00009f, ForceMode2D.Impulse);
        //collision.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

        spRndrer = collision.gameObject.GetComponent<SpriteRenderer>();

        StartCoroutine(Flash(0.05f));
        StartCoroutine(Knockback(0f, collision.gameObject.GetComponent<Rigidbody2D>(), collision.gameObject.transform.position));
    }

    void Start()
    {

    }

    void Update()
    {

    }

    IEnumerator Knockback(float knockDuration, Rigidbody2D rb2d, Vector2 dir)
    {
        var direction = transform.InverseTransformPoint(rb2d.transform.position);
        var x = (direction.x > 0f) ? -0.0004f : 0.0004f;
        var y = (direction.y > 0f) ? 0.0004f : -0.0004f;

        //var x = transform.position.x - rb2d.transform.position.x;
       // var y = transform.position.x - rb2d.transform.position.x;


        rb2d.AddForce(new Vector2(x, y), ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.3f);

        rb2d.velocity = Vector3.zero;

        yield return 0;
    }

    IEnumerator Flash(float x)
    {
        for (int i = 0; i < 10; i++)
        {
            spRndrer.enabled = false;
            yield return new WaitForSeconds(x);
            spRndrer.enabled = true;
            yield return new WaitForSeconds(x);
        }
    }
}