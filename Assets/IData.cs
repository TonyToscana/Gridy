
using UnityEngine;

abstract public class IData : MonoBehaviour
{
    public abstract string Load(string name);
    public abstract string Save(string name, string value);
}
