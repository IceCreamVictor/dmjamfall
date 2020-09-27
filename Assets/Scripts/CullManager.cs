using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CullManager : MonoBehaviour
{
    public static CullManager instance = null;

    Collider[] objectsToUpdate = null;
    
    [SerializeField] Transform kitchen = null;
    [SerializeField] Transform bathrooom = null;
    [SerializeField] Transform livinRoom = null;

    bool hasEntered = false;

    Room currentRoom = Room.None;


    void Awake()
    {
        instance = this;
    }

    public void EnterRoom(Room room, bool isFirst)
    {
        if (isFirst && currentRoom == room)
        {
            currentRoom = Room.None;
            ResetCull();
            return;
        }

        if (currentRoom == Room.None && isFirst)
            hasEntered = true;
        else if (!isFirst && currentRoom == Room.None)
        {
            currentRoom = room;
            UpdateCull();          
        }
    }

    void UpdateCull()
    {
        switch (currentRoom)
        {
            case Room.BathRoom:
                Collider[] array1 = Physics.OverlapBox(kitchen.position, kitchen.localScale / 2);
                Collider[] array2 = Physics.OverlapBox(livinRoom.position, livinRoom.localScale / 2);
                objectsToUpdate = new Collider[array1.Length + array2.Length];

                Array.Copy(array1, objectsToUpdate, array1.Length);
                Array.Copy(array2, 0, objectsToUpdate, array1.Length, array2.Length);
                break;
               
            default:
                objectsToUpdate = Physics.OverlapBox(bathrooom.position, bathrooom.localScale / 2);
                break;

        }

        for (int i = 0; i < objectsToUpdate.Length; i++)
        {
            if(!objectsToUpdate[i].CompareTag("Ground"))
                objectsToUpdate[i].gameObject.SetActive(false);
        }
    }

    void ResetCull()
    {
        for (int i = 0; i < objectsToUpdate.Length; i++)
        {
            objectsToUpdate[i].gameObject.SetActive(true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(kitchen.position, kitchen.localScale);
        Gizmos.DrawWireCube(bathrooom.position, bathrooom.localScale);
        Gizmos.DrawWireCube(livinRoom.position, livinRoom.localScale);
    } 
}

public enum Room
{
    None,
    Kitchen,
    LivingRoom,
    BathRoom
}
