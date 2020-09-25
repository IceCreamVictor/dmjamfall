using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitchWeapon : MonoBehaviour
{
    [SerializeField] List<GameObject> weapons = new List<GameObject>();
    int selected = 0;

    void Update()
    {
        if(Input.mouseScrollDelta.y != 0)
        {
            weapons[selected].SetActive(false);

            selected += Mathf.RoundToInt(Input.mouseScrollDelta.y);

            selected = Mathf.Clamp(selected, 0, weapons.Count - 1);

            weapons[selected].SetActive(true);
        }
    }

    public void AddWeapon(GameObject weapon)
    {
        weapons.Add(weapon);
    }
}
