using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private Timer timer;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        this.timer = gameObject.AddComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        this.timeText.text = "Time " + timer.ToString();
    }

    public string GetTime()
    {
        return timer.ToString();
    }
}
