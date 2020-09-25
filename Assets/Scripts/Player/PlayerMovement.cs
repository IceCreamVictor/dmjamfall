using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    private CharacterController characterController;

    [Header("Crouch")]
    [SerializeField] private KeyCode crouchKey;


    private void Start() {
        characterController = GetComponent<CharacterController>();
    }

    void Update(){
        Move();
        if(Input.GetKeyDown(crouchKey)){
            Crouch(true);
        }
        if(Input.GetKeyUp(crouchKey)){
            Crouch(false);
        }
    }

    void Crouch(bool crouch){
        

    }

void Move(){
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move =  transform.right * x + transform.forward * y;
        
        characterController.Move(move * movementSpeed * Time.deltaTime);
}

}