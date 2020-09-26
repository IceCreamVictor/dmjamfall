using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds = null;



}

[System.Serializable]
class Sound
{
    [Range(0, 1f)]
    public float vol = 1;
    [Range(.1f, 3f)]
    public float pitch = 1;
    public string name;

    public AudioClip clip;
    
}
