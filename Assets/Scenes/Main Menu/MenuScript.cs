using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] int levelToStart;

    public GameObject settings;
    public GameObject controls;

    public void StartGame(){
        SceneManager.LoadScene(levelToStart);
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void SettingsOpen()
    {
        settings.SetActive(true);
    }

    public void SettingsClose()
    {
        settings.SetActive(false);
    }

    public void ControlsOpen()
    {
        controls.SetActive(true);
    }

    public void ControlsClose()
    {
        controls.SetActive(false);
    }
}
