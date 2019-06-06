using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private Timer timer;
    public Text timeText;
    public float alienSpeed = 1.5f;
    public float alienDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MainTheme");
        this.timer = gameObject.AddComponent<Timer>();
        foreach(Enemy enemy in FindObjectsOfType<Enemy>())
        {
            enemy.GetComponent<AIPath>().speed = alienSpeed;
            enemy.GetComponent<EnemyAIDistance>().distance = alienDistance;
        }
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
