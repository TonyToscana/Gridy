using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnKeyReduceImageColor : MonoBehaviour
{
    [SerializeField] public KeyCode keyCode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyCode))
        {
            Image img = this.GetComponent<Image>();

            var tempColor = img.color;
            tempColor.a = 0.5f;
            img.color = tempColor;
        }
    }
}
