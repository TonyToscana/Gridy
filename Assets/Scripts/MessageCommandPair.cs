using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCommandPair
{
    public string Message = null;
    public string Command = null;

    public MessageCommandPair(string Message, string Command)
    {
        this.Message = Message;
        this.Command = Command;
    }

    public MessageCommandPair(string Message)
    {
        this.Message = Message;
    }
}
