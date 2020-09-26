using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public static float time = 0;
    public static float highScore = 0;

    public static bool isStarted = false;

    void Start()
    {
        time = 0;
        highScore = PlayerPrefs.GetFloat("HighScore");
    }

    void Update()
    {        
        if(isStarted)
            time += Time.deltaTime; 
    }
}
