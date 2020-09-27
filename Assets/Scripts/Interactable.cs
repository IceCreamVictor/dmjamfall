using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public delegate void Function();
    public Function function;

    public void DoSomething()
    {
        function?.Invoke();
    }

    [SerializeField] GameObject highlight = null;

    private void OnMouseOver()
    {
        if(CutsceneManager.instance.running == false)
        {
            if (Vector3.Distance(transform.position, Camera.main.transform.position) <= 6.5f)
                highlight.SetActive(true);
            else
                highlight.SetActive(false);
        }
        
    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
