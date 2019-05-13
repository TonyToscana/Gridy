using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSliderChanged(float newValue)
    {
        ChangeVolume(newValue);
    }

    public void OnValueChanged(bool state)
    {
        if(state)
        {
            MuteSound();
        } else
        {
            UnmuteSound();
        }

    }

    private void MuteSound()
    {
        //TODO mute sound
        Debug.Log("Sound muted");
    }

    private void UnmuteSound()
    {
        //TODO unmute sound
        Debug.Log("Sound unmuted");
    }

    private void ChangeVolume(float volume)
    {
        //TODO change sound volume level
        Debug.Log("Volume level changed to: " + volume);
    }
}
