using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObstacle : MonoBehaviour
{
    [SerializeField] public int DamageDone = 0;
    [SerializeField] public float DamageRate = 2.0f;

    SpriteRenderer spRndrer;
    private float NextDamage;

    void OnCollisionEnter2D(Collision2D col)
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!(Time.time > NextDamage)) return;

        Health playerHealth = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Health>();

        if (col.gameObject.tag != "Player") return;

        NextDamage = Time.time + DamageRate;
        playerHealth.Damage(DamageDone);
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


        //rb2d.AddForce(new Vector2(x, y), ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.3f);

        //rb2d.velocity = Vector3.zero;

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