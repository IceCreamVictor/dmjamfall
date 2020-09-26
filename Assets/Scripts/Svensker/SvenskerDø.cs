using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvenskerDø : MonoBehaviour
{
    [SerializeField] private GameObject smokeBombParticles;
    [SerializeField] private string killerTag = "Killer"; 
    
    [HideInInspector] public Flag currentFlag;

    public void SvenskaWaMouShindeiru(){
        //Display particle system

        Debug.Log("Die svenska");
        if(currentFlag != null)
            currentFlag.StopFlag();
        Instantiate(smokeBombParticles,this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    
    private void OnCollisionEnter(Collision other) {
         
         if (other.gameObject.tag == killerTag)
            SvenskaWaMouShindeiru();
    }

}
