using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{

    [Header("Crouch")]
    [Tooltip("Key pressed to crouch")]
    [SerializeField] private KeyCode crouchKey;
    [SerializeField] private Vector3 crouchYPos;
    [SerializeField] private Vector3 standupYPos;

    [Tooltip("Character controller from parent")]
    public CharacterController characterController;


    void Update()
    {
        if(Input.GetKeyDown(crouchKey))
            Crouch(true);
        if(Input.GetKeyUp(crouchKey))
            Crouch(false);    
    }

    public void Crouch(bool crouch)
    {
        if(crouch)
        {
            this.transform.localPosition = crouchYPos;
            characterController.height = 1;
            characterController.center = new Vector3(0, -0.5f,0);
        }
        else
        {
            this.transform.localPosition = standupYPos;
            characterController.height = 2;
            characterController.center = new Vector3(0,0,0);
        }
    }
}
