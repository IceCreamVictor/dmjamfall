using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvenskerDø : MonoBehaviour
{
    [SerializeField] private GameObject smokeBombParticles;    
    [HideInInspector] public Flag currentFlag;

    public void KillSwedish(float delay = 0f){
        ProgressManager.instance.AddKill();
        
        Debug.Log("Killed sweed");
        StartCoroutine(Kill(delay));
    }

    public void HideSwedish(float delay = 0f){
        Debug.Log("Hidden sweed");
        StartCoroutine(Kill(delay));        
    }
    IEnumerator Kill(float delay){
        
        yield return new WaitForSeconds(delay);

        //stop flag if existing
        if(currentFlag != null)
            currentFlag.StopFlag();
        //Particle system
        Instantiate(smokeBombParticles,this.transform.position, Quaternion.identity);
        //destroy
        Destroy(this.gameObject);
    }
}
