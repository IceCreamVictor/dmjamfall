using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : Interactable
{
    [SerializeField] WeaponType weapon;
    [SerializeField] Drawer toEnable;

    [SerializeField] bool goCutscene = false;
    [SerializeField] CutsceneSequence cutscene;
    [SerializeField] SvenskerSpawn svenskerSpawn;

    void Start()
    {
        function = Pickup;
    }

    void Pickup()
    {
        PlayerSwitchWeapon.instance.AddWeapon(weapon);
        
        if(toEnable != null)
            toEnable.enabled = true;

        if(goCutscene){
            CutsceneManager.instance.AddSequence(cutscene);
            svenskerSpawn.StartSpawning();

        }

        print("Destroy");
        Destroy(gameObject);
    }
}
