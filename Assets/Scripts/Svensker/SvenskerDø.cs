using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvenskerDø : MonoBehaviour
{
    [SerializeField] GameObject deathParticles;
    [SerializeField] GameObject smokeParticles;
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
        

        dead = true;

        Debug.Log("Killed sweed");
        StartCoroutine(Kill(delay, false));
    }

    public void HideSwedish(float delay = 0f){

        ProgressManager.instance.WasHidden();
        
        StartCoroutine(Kill(delay, true));        
    }
    IEnumerator Kill(float delay, bool isHide){
        
        yield return new WaitForSeconds(delay);

        //stop flag if existing
        if(currentFlag != null)
            currentFlag.StopFlag();
        //Particle system
        if (isHide)
        {
            Instantiate(deathParticles, this.transform.position, Quaternion.Euler(-90, 0, 0));
            AudioManager.instance.Play("Death" + Random.Range(1, 2));
        }
        else
        {
            Instantiate(smokeParticles, this.transform.position, Quaternion.identity);
            AudioManager.instance.Play("Smoke");
        }
        //destroy
        Destroy(transform.parent.gameObject);
    }
}
