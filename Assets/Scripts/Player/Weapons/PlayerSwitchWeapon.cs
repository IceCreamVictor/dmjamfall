using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitchWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] weaponsToAdd = null;
    List<GameObject> weapons = new List<GameObject>();
    int selected = 0;

    public static PlayerSwitchWeapon instance;
    private void Awake()
    {
        instance = this;
    }

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

    public void AddWeapon(WeaponType weapon)
    {
        weapons.Add(weaponsToAdd[(int)weapon]);

        if (weapons.Count == 1)
            weapons[0].SetActive(true);
    }
}

public enum WeaponType
{
    flyswatter,
    rubberband,
    flamethrower
}
