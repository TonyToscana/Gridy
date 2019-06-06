using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    [SerializeField] public float duration;
    [SerializeField] public GameObject prefab;
    public AudioClip soundDisappear;

    private static float timeInSeconds;
   
    // Start is called before the first frame update
    void Start()
    {
        timeInSeconds = 0;       
    }

    // Update is called once per frame
    void Update()
    {
       
        timeInSeconds += Time.fixedDeltaTime;
        if(timeInSeconds >= duration)
        {
            if (soundDisappear!= null)
            {
                AudioSource.PlayClipAtPoint(soundDisappear, transform.position);
            }

            Health health = FindObjectOfType<Health>();

            if (health != null)
            {
                health.ChangeState(health.Vulnerable);
            }

            Destroy(prefab);
        }
    }

  
}
