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
                AudioManager.instance.Play("NogetGalt");
                break;
            case 2:
                AudioManager.instance.Stop("NogetGalt");
                AudioManager.instance.Play("Static");              
                break;
            case 3:
                AudioManager.instance.Play("YndigtLand");
                AudioManager.instance.Stop("Static");
                break;
            case 4:
                AudioManager.instance.Play("Static");
                AudioManager.instance.Stop("YndigtLand");
                break;
            case 5:
                AudioManager.instance.Play("DeFørste");
                AudioManager.instance.Stop("Static");
                break;
            default:
                AudioManager.instance.Stop("DeFørste");
                AudioManager.instance.Play("Static");
                curSong = 0;
                break;
        }
    }
}
