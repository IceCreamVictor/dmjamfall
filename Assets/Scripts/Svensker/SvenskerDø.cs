using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvenskerDø : MonoBehaviour
{
    [SerializeField] private GameObject smokeBombParticles;    
    [HideInInspector] public Flag currentFlag;

    public void SvenskaWaMouShindeiru(float delay = 0f){
        
        StartCoroutine(Kill(delay));
    }

    IEnumerator Kill(float delay){
        
        Debug.Log("Die svenska");
        
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
