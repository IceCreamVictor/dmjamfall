using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] Animator anim;
    bool isOpen = false;

    public bool canOpen = false;

    void Start()
    {
        function = OpenDoor;   
    }
    void OpenDoor()
    {
        if (!isOpen && canOpen)
        {
            isOpen = true;
            anim.Play("RealDoorOpen");
        }
    }
}
