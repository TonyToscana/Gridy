using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorToPrefab
{
    [SerializeField] public Color color;
    [SerializeField] public GameObject prefab;
    [SerializeField] public bool autoRotate = false;
    [SerializeField] public float LayerZIndex = 0;
    [SerializeField] public bool UseLayerZIndex = false;
}
