using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvenskerRaycast : MonoBehaviour
{
    private Camera camera;

    private void Start() {
        camera = GetComponent<Camera>();
    }

    public float range = 100f;

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            Shoot();

        }
    }

    void Shoot(){
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }

    }

}
