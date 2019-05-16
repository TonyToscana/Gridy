using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DialogHolder : MonoBehaviour
{
    private Animator anim;
    [SerializeField] public ParticleSystem particles;

    private bool inside = false;

    void Start()
    {
        this.particles.Stop();
        this.anim = GetComponent<Animator>();
    }
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ENTER");
        if (inside == false)
        {
            inside = true;
            ShowDialog(other.gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        inside = false;
        FindObjectOfType<DialogManager>().Destroy();
    }

    public void ShowDialog(GameObject gameObject)
    {
        if (gameObject.tag.Equals("Player"))
        {
            DialogManager manager = FindObjectOfType<DialogManager>();

            manager.AddMessage("Hello. I see you are new in the craft.")
                   .AddMessage("This is a dangerous world. I will give you a shild to protext your self for 5 seconds.")
                   .AddMessage("Press ENTER to get the shild.", "Shield")
                   .OnReaded(MessageReaded)
                   .ShowBox();
        }
    }

    private object MessageReaded(int MessagesLeft)
    {
        if (MessagesLeft <= 0)
        {
            StartCoroutine(RunAnimationForSeconds(1f));
        }

        return null;
    }

    private IEnumerator RunAnimationForSeconds(float sec)
    {
        Debug.Log("ASD DA");
        this.particles.Play();
        this.anim.SetBool("wand", true);

        yield return new WaitForSeconds(sec);

        this.particles.Stop();
        this.anim.SetBool("wand", false);
    }
    
    void Update()
    {
        
    }
}
