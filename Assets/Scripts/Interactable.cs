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
}
