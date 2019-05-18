

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealths : MonoBehaviour, HealthListener
{
    private GameObject CharacterObject;
    private Health Health;
    private bool InitialHealthRender = false;
    private Queue<GameObject> HeartInstances;
    private bool healthListenerSet = false;

    //[SerializeField] public GameObject HeartPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("UI start executed");
        HeartInstances = new Queue<GameObject>();
        List<GameObject> children = new List<GameObject>();

        int i = 0;
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            //Debug.Log("Is child null? " + (child == null).ToString());
            //Debug.Log(child.GetSiblingIndex());
            //children.Insert(child.GetSiblingIndex(), child.gameObject);
            HeartInstances.Enqueue(child.gameObject);
        }

        //children.ForEach(x => HeartInstances.Enqueue(x));
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Health == null)
        {
            this.CharacterObject = GameObject.FindGameObjectWithTag("Player");

            if (this.CharacterObject != null)
            {
                this.Health = this.CharacterObject.GetComponent<Health>();
                
                if (Health == null) Debug.LogError("Health is null");
                if (this == null) Debug.LogError("this is null");

                if(!healthListenerSet)
                {
                    Debug.Log("SetListener executed");
                    healthListenerSet = true;
                    Health?.SetListener(this);
                }
                
            }
        }
    }

    public void OnDeath(int CurrentHealth, Health health)
    {
    }

    public void OnHeal(int CurrentHealth, Health health)
    {

    }

    public void OnDamage(int CurrentHealth, Health health)
    {
    }

    private void OnDisable()
    {
        //Health.RemoveListener(this);
        Debug.Log("OnDisble executed:");
    }

    public void OnLifeConsumed(int CurrentHealth, int CurrentLife, Health health)
    {
        if (HeartInstances.Count > 0)
        {
            Debug.Log("Are heartInstance null? " + (HeartInstances.Dequeue() == null).ToString());
            //Destroy(HeartInstances.Dequeue());
            HeartInstances.Dequeue().GetComponent<Image>().enabled = false;
        }
    }
}
