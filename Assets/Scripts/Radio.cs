using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : Interactable
{
    int curSong = 0;
    bool isStatic = true;

    [SerializeField] string[] songs = null;

    void Start()
    {
        AudioManager.instance.Play("Static");
        function = PlayRadio;
    }

    void PlayRadio()
    {
        if (isStatic)
        {
            AudioManager.instance.Play(songs[curSong]);
            AudioManager.instance.Stop("Static");

            curSong++;

            if (curSong == songs.Length)
            {
                curSong = 0;
            }

            isStatic = false;
        }
        else
        {
            if (curSong != 0)
                AudioManager.instance.Stop(songs[curSong - 1]);
            else
                AudioManager.instance.Stop(songs[songs.Length - 1]);

            AudioManager.instance.Play("Static");

            isStatic = true;
        }
    }
}
