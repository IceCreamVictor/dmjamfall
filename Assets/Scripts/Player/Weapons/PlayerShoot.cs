using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{  
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] float cooldown = 0.2f;
    [SerializeField] float range;
    [SerializeField] float bulletSpeed = 5f;

    private void OnEnable() {
        playerAttack.SetStats(cooldown, range);
        playerAttack.animFunc = PlayAnim;
        playerAttack.soundFunc = PlaySound;
    }

    public void PlayAnim(){
        //anim.Play("Smash");        
    }

    public void PlaySound(){
        //AudioManager.instance.PlayRandomPitch("Smack");
    }    
}
