using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Consumable : MonoBehaviour, ISubject
{
    public int calories = 0;
    public AudioClip CoinPicked;

    private bool pickUpAllowed = false;
    private bool taken = false;  

    private AudioManager audioManager;
    private List<IObserver> _observers = new List<IObserver>();

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();       
    }

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown("space"))
        {
            taken = true;
            FindObjectOfType<AudioManager>().Play("CoinPicked");
            DoAction();           
            Notify();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            pickUpAllowed = false;
        }
    }

    virtual protected void DoAction()
    {
        Points.GetInstance().Add(calories);
    }

    public void Attach(IObserver observer)
    {
        this._observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        this._observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
           observer.Update(this);
        }
    }
}
