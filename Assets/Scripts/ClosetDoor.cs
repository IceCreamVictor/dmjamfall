using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetDoor : Interactable
{
    [SerializeField] Animator anim = null;
    bool isOpen = false;

    private void Start()
    {
        function = OpenDoor;
    }

    void OpenDoor()
    {
        isOpen = !isOpen;

        if (isOpen)
            anim.Play("DoorOpen");
        else
            anim.Play("DoorClose");
    }
}
