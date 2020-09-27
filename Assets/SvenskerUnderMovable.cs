using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvenskerUnderMovable : MonoBehaviour
{
    [SerializeField] SvenskerSpawn svenskerSpawn;
    Rigidbody rigidbody;
    [SerializeField] BoxCollider collider;


    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
        collider = GetComponent<BoxCollider>();
        if(!canSpawn)
            collider.enabled = false;
    }   

    public void EnableObject(){
        collider.enabled = true;
        rigidbody.isKinematic = false;
        canSpawn = true;
    }

    public bool canSpawn;

    public void SpawnSvensker(){
        if(canSpawn) {
            svenskerSpawn.StartSpawning();
            rigidbody.isKinematic = false;
            canSpawn = false;
        }
    }

}
