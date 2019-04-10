using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public float speed = 0.4f;

    private CommandInvoker commandInvoker;
    
    // Start is called before the first frame update
    void Start()
    {
        this.commandInvoker = new CommandInvoker();

        this.commandInvoker.SetAlias(new List<string> { "UpArrow", "DownArrow", "LeftArrow", "RightArrow", "A", "S", "D", "W"}, "Move");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        CheckInput();
    }

    void CheckInput()
    {
        Vector3 move = Vector3.zero;

        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        if (Input.anyKey)
        {
            foreach (KeyCode item in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(item))
                {
                    ICommand cmd = this.commandInvoker.GetCommand(item.ToString());
                    cmd?.Execute();
                }
            }
        }
    }
}
