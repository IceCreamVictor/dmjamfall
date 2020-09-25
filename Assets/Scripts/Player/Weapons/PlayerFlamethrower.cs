using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlamethrower : MonoBehaviour
{
    [SerializeField] GameObject flame = null;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            flame.SetActive(true);
        }else
        {
            flame.SetActive(false);
        }
    }
}
