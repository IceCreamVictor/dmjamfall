using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtains : Interactable
{
    [SerializeField] Animator anim = null;
    bool isOpen = false;

    void Start()
    {
        function = MoveCurtains;
    }

    void MoveCurtains()
    {
        if (isOpen)
            return;

        Collider[] cols = GetComponents<Collider>();

        for (int i = 0; i < cols.Length; i++)
        {
            cols[i].enabled = false;
        }

        isOpen = true;
        anim.Play("CurtainsMove");
    }
}
