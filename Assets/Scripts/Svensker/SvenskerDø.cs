using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvenskerDø : MonoBehaviour
{
    [SerializeField] private GameObject deathParticles;    
    [HideInInspector] public Flag currentFlag;

    float health = 2;
    bool dead = false;

    public void BurnSwedish()
    {
        health -= Time.fixedDeltaTime;
        if(health <= 0 && !dead)
        {
            KillSwedish();
        }
    }


    public void KillSwedish(float delay = 0f){
        ProgressManager.instance.AddKill();
        AudioManager.instance.Play("Death" + Random.Range(1, 2));

        dead = true;

        Debug.Log("Killed sweed");
        StartCoroutine(Kill(delay));
    }

    public void HideSwedish(float delay = 0f){

        ProgressManager.instance.WasHidden();
        
        StartCoroutine(Kill(delay));
    }
    IEnumerator Kill(float delay){
        
        yield return new WaitForSeconds(delay);

        //stop flag if existing
        if(currentFlag != null)
            currentFlag.StopFlag();
        //Particle system
        Instantiate(deathParticles, this.transform.position, Quaternion.Euler(-90,0,0));
        //destroy
        Destroy(transform.parent.gameObject);
    }
}
