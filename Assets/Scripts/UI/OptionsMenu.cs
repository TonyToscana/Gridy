using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    private GameManager gameManager;

    private float savedVolume;

    public static OptionsMenu instance;

    private Slider slider;
    private static float sliderValue = 0f;

    private Toggle toggle;
    private static bool toggleValue = false;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        toggle = GetComponentInChildren<Toggle>();
        slider.value = sliderValue;
        toggle.isOn = toggleValue;
        
        gameManager = gameObject.AddComponent<GameManager>();

        if (gameManager)
        {
            Debug.Log("GM encontrado");
        } else
        {
            Debug.Log("GM no encontrado");
        }
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

    public void OnButtonClicked()
    {
        gameObject.SetActive(false);
    }

    private void MuteSound()
    {
        Debug.Log("Sound muted");
        toggleValue = toggle.isOn;

        audioMixer.GetFloat("volume", out savedVolume);
        audioMixer.SetFloat("volume", -80f);
    }

    private void UnmuteSound()
    {
        Debug.Log("Sound unmuted");
        toggleValue = toggle.isOn;

        audioMixer.SetFloat("volume", savedVolume);
    }

    private void ChangeVolume(float volume)
    {
        Debug.Log("Volume level changed to: " + volume);
        sliderValue = slider.value;
        savedVolume = volume;

        if(!toggle.isOn)
            audioMixer.SetFloat("volume", volume);

    }
}
