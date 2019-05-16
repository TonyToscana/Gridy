using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public AudioMixer audioMixer;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.outputAudioMixerGroup = s.audioMixerGroup;//audioMixer.FindMatchingGroups("Master")[0];
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s?.source.Play();
        s.isPaused = false;
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s?.source.Stop();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s?.source.Pause();
        s.isPaused = true;
    }

    public void PauseAllPlaying()
    {
        foreach (Sound s in sounds)
        {
            if(s.source.isPlaying)
            {
                s.source.Pause();
                s.isPaused = true;
            }
                
        }
    }

    public void ResumePaused()
    {
        foreach (Sound s in sounds)
        {
            if(s.isPaused)
            {
                s.source.Play();
                s.isPaused = false;
            }
                
        }
    }
}
