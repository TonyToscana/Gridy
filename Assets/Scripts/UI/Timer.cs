﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timeInSeconds;
    // Start is called before the first frame update
    void Start()
    {
        timeInSeconds = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeInSeconds += Time.deltaTime;
    }

    public string formatTime()
    {
        return formatTime(this.timeInSeconds);
    }

    public static string formatTime(float timeInSeconds)
    {
        int seconds = (int)(timeInSeconds % 60f);
        int minutes = (int)(timeInSeconds / 60f);
        int hours = minutes % 60;
        minutes /= 60;

        return formatNumber(hours) + ":" + formatNumber(minutes) + ":" + formatNumber(seconds);
    }

    private static string formatNumber(float number)
    {
        if (number < 10f)
        {
            return "0" + number;
        }
        else return number.ToString();
    }

    override public string ToString()
    {
        return this.formatTime();
    }

    public float GetTime()
    {
        return this.timeInSeconds;
    }
}
