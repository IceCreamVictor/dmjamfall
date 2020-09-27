using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashGlass : MonoBehaviour
{
    [SerializeField] GameObject glass = null;
    [SerializeField] GameObject glassBreak = null;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Hammer")
        {
            Instantiate(glassBreak, transform.position, transform.rotation);
            Destroy(glass);
        }
    }
}
