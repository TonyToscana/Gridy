using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime 
{

    private static GameTime instance = null;
    private float _time = 0;

    public GameTime() { }

    public float Seconds
    {

        get {

            return _time;
        }
        set {

            _time = value;
        }
    }

    public void Add(float p)
    {
        Seconds += p;
    }

    public void Sub(float p)
    {
        Seconds -= p;
    }

    public void Zero()
    {
        Seconds = 0;
    }

    public void Set(float p)
    {
        Seconds = p;
    }

    public static GameTime GetInstance()
    {
        if (instance == null)
        {
            instance = new GameTime();
        }

        return instance;
    }

}
