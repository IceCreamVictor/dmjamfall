using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : Interactable
{
    int curSong = 0;
    void Start()
    {
        AudioManager.instance.Play("Static");
        function = PlayRadio;
    }

    void PlayRadio()
    {
        curSong++;

        switch(curSong)
        {
            case 1:
                AudioManager.instance.Stop("Static");
                break;

            default:
                AudioManager.instance.Play("Static");
                curSong = 0;
                break;
        }

        
    }
}
