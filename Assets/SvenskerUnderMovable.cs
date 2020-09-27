using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvenskerUnderMovable : MonoBehaviour
{
    [SerializeField] SvenskerSpawn svenskerSpawn;
    Rigidbody rigidbody;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }   

    public bool canSpawn = true;

    public void SpawnSvensker(){
        if(canSpawn) {
            svenskerSpawn.StartSpawning();
            rigidbody.isKinematic = false;
            canSpawn = false;
        }
    }

}
