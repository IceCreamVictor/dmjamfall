using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : Interactable
{
    [SerializeField] AudioClip[] songs = null;
    void Start()
    {
        function = PlayRadio;
    }

    void PlayRadio()
    {
        
    }
}
