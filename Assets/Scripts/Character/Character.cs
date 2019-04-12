using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public float speed = 0.4f;
    [HideInInspector] public KeyCode LastDirectionKey = KeyCode.None;
    [HideInInspector] public KeyCode PrevDirectionKey = KeyCode.None;
    [HideInInspector] public IList<string> MovementKeysList = new List<string> { "UpArrow", "DownArrow", "LeftArrow", "RightArrow", "A", "S", "D", "W" };


    private CommandInvoker commandInvoker;
    
    // Start is called before the first frame update
    void Start()
    {
        this.commandInvoker = new CommandInvoker();

        this.commandInvoker.SetAlias(this.MovementKeysList, "Move");
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
                    ICommand cmd = this.commandInvoker.GetCommand(LastDirectionKey.ToString());
                    cmd?.Execute();
                    break;
                }
            }
        }
    }
}
