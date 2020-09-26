using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlamethrower : MonoBehaviour
{
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] GameObject flame = null;
    [SerializeField] Collider cols = null;

    bool isFiring = false;
    bool wasFiring = false;

    private void OnEnable()
    {
        playerAttack.SetStats(0, 0, 0);

        playerAttack.animFunc = Flame;

    }

    void Flame()
    {
        isFiring = true;

        if (!wasFiring)
        {
            AudioManager.instance.Play("Flamethrower");           
        }
    }

    void LateUpdate()
    {
        if(!isFiring && !wasFiring)
        {
            AudioManager.instance.Stop("Flamethrower");
        }

        wasFiring = isFiring;

        cols.enabled = isFiring;
        flame.SetActive(isFiring);

        isFiring = false;
    }


    void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<SvenskerDø>() != null)
            other.GetComponent<SvenskerDø>().BurnSwedish();
    }
}
