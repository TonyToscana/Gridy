using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class DialogManager : MonoBehaviour
{
    public GameObject DialogBox;
    public Text DialogText;
    public Text CloseNextText;

    private AudioSource audio;

    private bool CanClose;
    private bool DialogActive;

    private Queue<MessageCommandPair> QueueText;
    private MessageCommandPair CurrentMessage;
    private CommandInvoker commandInvoker;

    // Start is called before the first frame update
    void Start()
    {
        this.audio = GetComponent<AudioSource>();

        this.commandInvoker = CommandInvoker.GetInstance();
        this.QueueText = new Queue<MessageCommandPair>();
        this.DialogBox.SetActive(false);
        this.CloseNextText.gameObject.SetActive(false);
        this.DialogActive = false;
        this.CanClose = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogActive && Input.GetKeyDown(KeyCode.Return) && this.CloseNextText.gameObject.activeSelf)
        {
            if (this.CurrentMessage != null && this.CurrentMessage.Command != null && !this.CurrentMessage.Command.Equals(""))
            {
                ICommand cmd = this.commandInvoker.GetCommand(this.CurrentMessage.Command);
                cmd?.Execute();
            }

            if (this.CanClose)
            {
                this.DialogBox.SetActive(false);
                this.DialogActive = false;
            }
            else 
            {
                ShowBox();
            }
        }
    }

    public DialogManager AddMessage(MessageCommandPair msg)
    {
        this.QueueText.Enqueue(msg);

        return this;
    }

    public DialogManager AddMessage(string msg)
    {
        this.QueueText.Enqueue(new MessageCommandPair(msg, null));

        return this;
    }

    public DialogManager AddMessage(string msg, string cmd)
    {
        this.QueueText.Enqueue(new MessageCommandPair(msg, cmd));

        return this;
    }

    public void ShowBox()
    {
        this.audio.Play();

        DialogActive = true;
        DialogBox.SetActive(true);
        this.CloseNextText.gameObject.SetActive(false);

        this.CurrentMessage = QueueText.Dequeue();
        this.CanClose = (this.QueueText.Count < 1);
        
        if (this.QueueText.Count >= 1)
        {
            CloseNextText.text = "Press [ENTER] to continue.";
        } 
        else
        {
            CloseNextText.text = "Press [ENTER] to close.";
        }
        
        StartCoroutine(TypeText(this.CurrentMessage));
    }

    private IEnumerator TypeText(MessageCommandPair msg)
    {
        for (int i = 0; i < msg.Message.Length; i++)
        {
            string currText = msg.Message.Substring(0, i);
            DialogText.text = currText;

            yield return new WaitForSeconds(0.005f);
        }

        this.CloseNextText.gameObject.SetActive(true);
    }
}
