﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public float speed = 4.4f;
    [HideInInspector] public KeyCode LastDirectionKey = KeyCode.None;
    [HideInInspector] public KeyCode PrevDirectionKey = KeyCode.None;
    [HideInInspector] public IList<string> MovementKeysList = new List<string> { "UpArrow", "DownArrow", "LeftArrow", "RightArrow", "A", "S", "D", "W" };


    private CommandInvoker commandInvoker;
    
    // Start is called before the first frame update
    void Start()
    {
        this.commandInvoker = CommandInvoker.GetInstance();

        this.commandInvoker.SetAlias(this.MovementKeysList, "Move");
        this.commandInvoker.SetAlias("Space", "Shield");
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
    }

    void CheckInput()
    {   
        if (Input.anyKey)
        {
            foreach (KeyCode item in System.Enum.GetValues(typeof(KeyCode)))
            {
                string commandString = "";

                if (Input.GetKey(item))
                {
                    if (this.MovementKeysList.Contains(item.ToString()))
                    {
                        this.PrevDirectionKey = this.LastDirectionKey;
                        this.LastDirectionKey = item;
                    }
                }

                if (Input.GetKey(item))
                {
                    ICommand cmd = this.commandInvoker.GetCommand(item.ToString());
                    cmd?.Execute();
                    break;
                }
            }
        }
    }
}
