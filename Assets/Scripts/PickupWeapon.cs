using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : Interactable
{
    [SerializeField] WeaponType weapon;
    [SerializeField] Drawer toEnable;
    [SerializeField] GameObject reolCutscene;

    [SerializeField] bool goCutscene = false;
    [SerializeField] CutsceneSequence cutscene;
    [SerializeField] SvenskerSpawn svenskerSpawn;

    [SerializeField] private bool flameThrower;

    [SerializeField] private CutsceneTrigger cutsceneTrugger;

    void Start()
    {
        function = Pickup;
    }

    void Pickup()
    {
        PlayerSwitchWeapon.instance.AddWeapon(weapon);
        
        if(toEnable != null){
            toEnable.enabled = true;
            reolCutscene.SetActive(true);
        }

        if(goCutscene){
            CutsceneManager.instance.AddSequence(cutscene);
            svenskerSpawn.StartSpawning();

        }

        if(flameThrower){
            svenskerSpawn.StartSpawning();
            cutsceneTrugger.PlayCutscene();
        }

        print("Destroy");
        Destroy(gameObject);
    }
}
