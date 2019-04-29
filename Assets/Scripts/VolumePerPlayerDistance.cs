using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VolumePerPlayerDistance : MonoBehaviour
{
    private AudioSource audio;
    void Start()
    {
        this.audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null) return;

        float dist = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        float vol = 0.3f;

        this.audio.volume = 1 - (dist / 5);
    }
}
