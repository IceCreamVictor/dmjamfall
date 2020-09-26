using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvenskerDø : MonoBehaviour
{
    //[SerializeField] private GameObject transitionParticleSystem
    [SerializeField] private string killerTag = "Killer"; 
    
    [HideInInspector] public Flag currentFlag;

    public void SvenskaWaMouShindeiru(){
        //Display particle system

        Debug.Log("Die svenska");
        if(currentFlag)
            currentFlag.StopFlag();
        Destroy(this.gameObject);
    }
    
    private void OnCollisionEnter(Collision other) {
         
         if (other.gameObject.tag == killerTag)
            SvenskaWaMouShindeiru();
    }

}
