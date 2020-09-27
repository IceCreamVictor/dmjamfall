using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExit : MonoBehaviour
{
    [SerializeField] Room room;
    [SerializeField] bool isFirst;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CullManager.instance.EnterRoom(room, isFirst);
        }
    }
}
