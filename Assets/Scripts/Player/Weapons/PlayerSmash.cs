using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSmash : MonoBehaviour
{
    [SerializeField] Animator anim = null;
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] float cooldown = 1f;
    [SerializeField] float range;
    [SerializeField] float killDelay;

    private void OnEnable() {
        playerAttack.SetStats(cooldown, range, killDelay);
        playerAttack.animFunc = PlayAnim;
        playerAttack.soundFunc = PlaySound;
    }

    public void PlayAnim(){
        anim.Play("Smash");        
    }

    public void PlaySound(){
        AudioManager.instance.PlayRandomPitch("Smack");
    }    
}
