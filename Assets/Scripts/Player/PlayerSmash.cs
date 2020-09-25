using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSmash : MonoBehaviour
{
    [SerializeField] Animator anim = null;
    [SerializeField] Transform smasher = null;
    Vector3 newPos = Vector3.zero;
    Vector3 defaultPos = Vector3.zero;

    private void Start()
    {
        defaultPos = transform.localPosition;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(newPos != Vector3.zero)
        {
            //smasher.position = Vector3.Lerp(smasher.position, newPos, 0.2f);
        }
        else
        {
            smasher.localPosition = defaultPos;
        }

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.distance < 2.5f)
                {
                    newPos = hit.point;
                    newPos.y += 0.5f;
                }
            }

            anim.Play("Smash");
        }       
    }

    public void StopMoving()
    {
        newPos = Vector3.zero;
    }
}
