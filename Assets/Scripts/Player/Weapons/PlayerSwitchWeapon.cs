using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitchWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] weaponsToAdd = null;
    [SerializeField] GameObject[] selectedUI = null;
    [SerializeField] GameObject[] weaponImage = null;
    [SerializeField] GameObject[] questionMark = null;

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
            selectedUI[selected].SetActive(false);
            
            selected += Mathf.RoundToInt(Input.mouseScrollDelta.y);

            selected = Mathf.Clamp(selected, 0, weapons.Count - 1);

            
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (weapons[0] != null)
            {
                weapons[selected].SetActive(false);
                selectedUI[selected].SetActive(false);

                selected = 0;

                selectedUI[selected].SetActive(true);
                weapons[selected].SetActive(true);
            }
        }else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (weapons[1] != null)
            {
                weapons[selected].SetActive(false);
                selectedUI[selected].SetActive(false);

                selected = 1;

                selectedUI[selected].SetActive(true);
                weapons[selected].SetActive(true);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (weapons[2] != null)
            {
                weapons[selected].SetActive(false);
                selectedUI[selected].SetActive(false);

                selected = 2;

                selectedUI[selected].SetActive(true);
                weapons[selected].SetActive(true);
            }
        }

    }

    public void AddWeapon(WeaponType weapon)
    {
        weapons.Add(weaponsToAdd[(int)weapon]);

        weaponImage[(int)weapon].SetActive(true);
        questionMark[(int)weapon].SetActive(false);

        if (weapons.Count == 1)
        {
            selectedUI[0].SetActive(true);
            weapons[0].SetActive(true);
        }
    }
}

public enum WeaponType
{
    flyswatter,
    rubberband,
    flamethrower
}
