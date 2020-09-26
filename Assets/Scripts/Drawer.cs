using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Interactable
{
    [SerializeField] Animator anim = null;

    bool isOpen = false;

    void Start()
    {
        function = MoveDrawer;
    }

    void MoveDrawer()
    {
        print("Open");
        isOpen = !isOpen;

        if (isOpen)
            anim.Play("DrawerOpen");
        else
            anim.Play("DrawerClose");

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Moveable"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.CompareTag("Moveable"))
        {
            if(collision.collider.transform.parent == transform)
            {
                collision.collider.transform.parent = null;
            }
        }
    }
}
