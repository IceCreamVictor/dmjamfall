using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : Interactable
{
    [SerializeField] WeaponType weapon;

    void Start()
    {
        function = Pickup;
    }

    void Pickup()
    {
        print("AAAAA");
        PlayerSwitchWeapon.instance.AddWeapon(weapon);

        Destroy(gameObject);
    }
}
