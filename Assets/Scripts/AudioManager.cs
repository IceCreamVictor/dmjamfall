using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds = null;

    public static AudioManager instance;

    void Awake()
    {
        instance = this;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mixer;

            s.source.volume = s.vol;
            s.source.pitch = s.pitch;

            s.source.playOnAwake = false;

            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Play();
    }

    public void PlayRandomPitch(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.pitch = UnityEngine.Random.Range(0.5f, 2f);

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();
    }
}

[System.Serializable]
class Sound
{
    public string name;
    [Range(0, 1f)]
    public float vol = 1;
    [Range(.1f, 3f)]
    public float pitch = 1;

    public bool loop;

    public AudioClip clip;
    [HideInInspector] public AudioSource source;
    public AudioMixerGroup mixer;
}
