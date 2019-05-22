using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] public float RotationSpeed = 2.0f;
    [SerializeField] public bool RotateClockwise = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (RotateClockwise)
        {
            transform.Rotate(Vector3.back * RotationSpeed * Time.deltaTime * 100);
        }
        else
        {
            transform.Rotate(Vector3.forward * RotationSpeed * Time.deltaTime * 100);
        }
    }
}
