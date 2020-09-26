using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Interactable
{
    [SerializeField] Animator anim = null;
    [SerializeField] Rigidbody rb = null;

    bool isOpen = false;

    void Start()
    {
        function = MoveDrawer;
    }

    void MoveDrawer()
    {
        print("Open");
        isOpen = !isOpen;

        rb.isKinematic = isOpen;

        if (isOpen)
            anim.Play("DrawerOpen");
        else
            anim.Play("DrawerClose");

    }
}
