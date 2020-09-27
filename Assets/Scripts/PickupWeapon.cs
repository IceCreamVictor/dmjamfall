using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : Interactable
{
    [SerializeField] WeaponType weapon;
    [SerializeField] Drawer toEnable;

[SerializeField] bool goCutscene;
    [SerializeField] CutsceneSequence cutscene;
    [SerializeField] SvenskerSpawn svenskerSpawn;

    void Start()
    {
        function = Pickup;
    }

    void Pickup()
    {
        print("AAAAA");
        PlayerSwitchWeapon.instance.AddWeapon(weapon);
            toEnable.enabled = true;

        if(goCutscene){
            CutsceneManager.instance.AddSequence(cutscene);
            svenskerSpawn.StartSpawning();

        }
        Destroy(gameObject);

    }
}
