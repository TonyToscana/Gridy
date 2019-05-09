using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealth : MonoBehaviour, HealthListener
{
    private GameObject CharacterObject;
    private Health Health;
    private bool InitialHealthRender = false;
    private Queue<GameObject> HeartInstances;

    [SerializeField] public GameObject HeartPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        HeartInstances = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!InitialHealthRender)
        {
            if (this.Health == null)
            {
                this.CharacterObject = GameObject.FindGameObjectWithTag("Player");

                if (this.CharacterObject != null)
                {
                    this.Health = this.CharacterObject.GetComponent<Health>();
                }
            }
            else
            {
                for (int i = 0; i < this.Health.CurrentHealth; i++)
                {
                    Vector2 pos = new Vector2(this.transform.position.x + (64f * i), this.transform.position.y);
                    GameObject obj = Instantiate(HeartPrefab, pos, Quaternion.identity);

                    obj.transform.localScale = new Vector3(1f, 1f , 0f);
                    obj.transform.parent = this.gameObject.transform;

                    HeartInstances.Enqueue(obj);
                }

                Health.SetListener(this);

                InitialHealthRender = true;
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
        if (HeartInstances.Count > 0)
        {
            Destroy(HeartInstances.Dequeue());
        }
    }
}
