using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] int levelToStart;
    

    public void StartGame(){
        SceneManager.LoadScene(levelToStart);
    }

    public void ExitGame(){
        Application.Quit();
    }
}
