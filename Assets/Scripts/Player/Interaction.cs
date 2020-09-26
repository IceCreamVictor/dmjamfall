using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public static bool isCarrying = false;
    moveObject objectToMove;
    [SerializeField] Transform holder = null;

    private void Start()
    {
        objectToMove = new moveObject();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));
            RaycastHit hit;

            if(objectToMove.target != null)
            {
                objectToMove.target.parent = null;
                objectToMove.rb.isKinematic = false;
                objectToMove.target.gameObject.layer = 0;
                objectToMove.target.localScale = objectToMove.startSize;

                isCarrying = false;
                objectToMove = new moveObject();
                return;
            }

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.CompareTag("Moveable"))
                {
                    AudioManager.instance.Play("PickUp");

                    isCarrying = true;

                    objectToMove.target = hit.transform;
                    objectToMove.rb = hit.rigidbody;

                    //objectToMove.target.gameObject.layer = 8;
                    objectToMove.startSize = objectToMove.target.localScale;
                    objectToMove.rb.isKinematic = true;
                    objectToMove.target.SetParent(holder);
                    objectToMove.target.localPosition = Vector3.forward * 3f;
                }
                else if(hit.collider.CompareTag("Interactable"))
                {
                    hit.collider.GetComponent<Interactable>().DoSomething();
                }
            }
        }
    }

    struct moveObject
    {
        public Transform target;
        public Vector3 startSize;
        public Rigidbody rb;
    }
}
