using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils 
{
    public static Vector3 CloneVector3(Vector3 src)
    {
        Vector3 result = new Vector3(src.x, src.y, src.z);

        return result;
    }
}
