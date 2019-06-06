using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPositionRecalculate : MonoBehaviour
{
    public float AddToY = 0;
    public float AddToX = 0;

    void Start()
    {
        this.transform.position = new Vector3( this.transform.position.x + AddToX,
                                                this.transform.position.y + AddToY,
                                                this.transform.position.z );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
