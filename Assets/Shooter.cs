using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] public GameObject InitPosition;
    [SerializeField] public GameObject MissilePrefab;
    [SerializeField] public float CooldownTime = 2;
    [SerializeField] public float damage = 20;
    [HideInInspector] public bool used = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
