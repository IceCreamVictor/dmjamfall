using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Endscreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText, highScore;

    void Start()
    {
        ScoreTracker.isFinished = true;

        Cursor.lockState = CursorLockMode.None;

        ScoreTracker.hasCompleted = true;
        PlayerPrefs.SetString("Completed", "Completed");

        if (ScoreTracker.time < ScoreTracker.highScore)
        {
            ScoreTracker.highScore = ScoreTracker.time;
            PlayerPrefs.SetFloat("Highscore", ScoreTracker.highScore);
        }


        scoreText.text = ScoreTracker.time.ToString() + " sekunder";
        highScore.text = "Din rekord er " + ScoreTracker.highScore.ToString();   
    }

    public void TryAgain()
    {

    }
}
