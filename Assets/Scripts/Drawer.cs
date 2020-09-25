using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Interactable
{
    [SerializeField] Animator anim;

    bool isOpen = false;

    void Start()
    {
        function = MoveDrawer;
    }

    void MoveDrawer()
    {
        isOpen = !isOpen;

        if (isOpen)
            anim.Play("DrawerOpen");
        else
            anim.Play("DrawerClose");

    }
}
