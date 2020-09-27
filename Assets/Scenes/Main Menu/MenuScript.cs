using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public static float sens = 1;

    [SerializeField] int levelToStart;

    public GameObject settings;
    public GameObject controls;

    [SerializeField] Slider sensSlider = null;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        sens = PlayerPrefs.GetFloat("Sens") == float.NaN ? 1 : PlayerPrefs.GetFloat("Sens");

        sensSlider.value = sens;
    }

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

    public void ChangeSens(float newSens)
    {
        sens = newSens;

        PlayerPrefs.SetFloat("Sens", newSens);
    }
}
