using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletLid : Interactable
{
    [SerializeField] Animator anim = null;
    bool isOpen = false;
    void Start()
    {
        function = MoveLid;
    }

    void MoveLid()
    {
        isOpen = !isOpen;

        if (isOpen)
            anim.Play("LidOpen");
        else
            anim.Play("LidClose");

    }
}
