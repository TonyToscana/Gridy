using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public Rigidbody2D body2d;
    public float leftPushRange;
    public float righPushRange;
    public float velocity;

    void Start()
    {
        this.body2d = GetComponent<Rigidbody2D>();
        body2d.angularVelocity = velocity;
    }

    void Update()
    {
        if (transform.rotation.z > 0 &&
            transform.rotation.z < this.righPushRange &&
            body2d.angularVelocity > 0 &&
            body2d.angularVelocity < velocity)
        {
            body2d.angularVelocity = velocity;
        }
        else if (transform.rotation.z < 0 &&
                 transform.rotation.z > this.leftPushRange &&
                 body2d.angularVelocity < 0 &&
                 body2d.angularVelocity > velocity * -1)
        {
            body2d.angularVelocity = velocity * -1;
        }
    }
}
