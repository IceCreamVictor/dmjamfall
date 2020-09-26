using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Camera camera;
    private float range;
    private float cooldown;
    private float counter;
    private float killDelay;
    [HideInInspector]public  delegate void VoidDelegate();
    [HideInInspector] public VoidDelegate soundFunc;
    [HideInInspector] public VoidDelegate animFunc;
    private VoidDelegate killSwedish;

    public void SetStats(float _cooldown, float _range, float _killDelay = 0){
        cooldown = _cooldown;
        range = _range;
        killDelay = _killDelay;
    }

    private void Start() {
        camera = GetComponent<Camera>();
    }

    public bool CanAttack()
    {
        if(counter <= 0)
            return true;
        else
            return false;
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            Shoot();
        }

        if(counter > 0){
            counter -= Time.deltaTime;
        }
    }

    void Shoot(){

    if(CanAttack()){
        counter = cooldown;
        animFunc();
               
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            soundFunc();
            SvenskerDø sd = hit.transform.GetComponent<SvenskerDø>();
                if(sd != null)
                    sd.SvenskaWaMouShindeiru(killDelay);             

            }
        }
    }
}
