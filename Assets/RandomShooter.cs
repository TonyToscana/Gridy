using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShooter : MonoBehaviour
{
    [SerializeField] public GameObject missile;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot(UnityEngine.Random.Range(3, 7)));

    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator Shoot(int v)
    {
        yield return new WaitForSeconds(v);
        int missileNumber = UnityEngine.Random.Range(1, 5);

        for (int i = 0; i < missileNumber; i++)
        {
            GameObject missile = Instantiate(this.missile, this.transform.position, Quaternion.identity);
            missile.transform.parent = null;

            Vector2 dir = new Vector2(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10));

            missile.GetComponent<Rigidbody2D>().AddForce(dir * 30);

            yield return new WaitForSeconds(UnityEngine.Random.Range(0, 1.5f));
        }

        Destroy(this.gameObject);
    }
}
