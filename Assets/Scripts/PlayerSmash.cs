using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSmash : MonoBehaviour
{
    [SerializeField] Animator anim = null;
    [SerializeField] Transform smasher = null;
    Vector3 newPos = Vector3.zero;


    void Start()
    {
        
    }

    void Update()
    {
        if(newPos != Vector3.zero)
        {

        }


        if(Input.GetKeyDown(KeyCode.Return))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector2(0.5f, 0.5f));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.distance < 2f)
                {

                }
            }

            anim.Play("Smash");
        }       
    }

    public void StopMoving()
    {
        
    }
}
