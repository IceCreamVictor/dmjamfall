using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{  
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] float cooldown = 0.2f;
    [SerializeField] float range;

    [SerializeField] Transform gun = null;
    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] float upSpeed;

    private void OnEnable() {
        playerAttack.SetStats(cooldown, range);
        playerAttack.animFunc = PlayAnim;
        playerAttack.soundFunc = PlaySound;
    }

    public void PlayAnim(){

        GameObject bullet = Instantiate(bulletPrefab, gun.position, gun.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed + transform.up * upSpeed;

        Destroy(bullet, 1f);
    }

    public void PlaySound(){
        //AudioManager.instance.PlayRandomPitch("Smack");
    }    
}
