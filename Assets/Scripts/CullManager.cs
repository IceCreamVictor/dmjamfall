using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullManager : MonoBehaviour
{
    Collider[] objectsInKitchen = null;
    Collider[] objectsInBathroom = null;
    Collider[] objectsInLivingRoom = null;

    [SerializeField] Transform livinRoom = null;
    [SerializeField] Vector3 livinRoomSize = Vector3.zero;


    bool hasExited = false;

    void Start()
    {
        
    }
    
    void Update()
    {
        objectsInLivingRoom = Physics.OverlapBox(livinRoom.position, livinRoomSize);        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(livinRoom.position, livinRoomSize);
    }
}
