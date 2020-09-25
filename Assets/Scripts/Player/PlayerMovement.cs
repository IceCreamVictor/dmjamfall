using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    private CharacterController characterController;

    private void Start() {
        characterController = GetComponent<CharacterController>();
    }

    void Update(){
        Move();
    }

    void Move(){
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move =  transform.right * x + transform.forward * y;
        
        characterController.Move(move * movementSpeed * Time.deltaTime);
        this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
    }
}