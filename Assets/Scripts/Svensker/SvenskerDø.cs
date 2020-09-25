using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvenskerDø : MonoBehaviour
{
    //[SerializeField] private GameObject transitionParticleSystem
    [SerializeField] private string killerTag = "Killer"; 
    
    public void SvenskaWaMouShindeiru(){
        //Display particle system

        Debug.Log("Die svenska");
        Destroy(this.gameObject);
    }
    
    private void OnCollisionEnter(Collision other) {
         
         if (other.gameObject.tag == killerTag)
            SvenskaWaMouShindeiru();
    }

}
