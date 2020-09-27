using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    public static float time = 0;
    public static float highScore = 0;

    public static bool isFinished = false;
    public static bool hasCompleted = false;

    [SerializeField] TextMeshProUGUI timeText = null;

    void Start()
    {
        isFinished = true;

        hasCompleted = PlayerPrefs.HasKey("Completed");

        timeText.gameObject.SetActive(hasCompleted);

        time = 0;
        highScore = PlayerPrefs.GetFloat("HighScore");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (isFinished)
        {
            time += Time.deltaTime;
            if(hasCompleted)
            {
                timeText.text = time.ToString();
            }
        }       
    }
}
