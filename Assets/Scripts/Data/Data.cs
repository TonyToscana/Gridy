using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : IData
{
    public override string Save(string name, string value)
    {
        PlayerPrefs.SetString(name, value);
        PlayerPrefs.Save();

        return value;
    }


    public override string Load(string name)
    {
        Debug.Log("DSA original");

        return PlayerPrefs.GetString(name);
    }
}

