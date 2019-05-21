using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPoints : MonoBehaviour
{
    private Points Points;

    void Start()
    {
        Points = Points.GetInstance();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Text text = GetComponent<Text>();

        if (text == null) return;

        text.text = "Puntos: " + Points.Number;
    }
}
