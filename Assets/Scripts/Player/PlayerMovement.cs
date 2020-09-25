using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [Tooltip("For calculating player's y position")]
    [SerializeField] private float floorY_pos;
    [Tooltip("For calculating player's y position")]
    [SerializeField] private float playerHeight;
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
        this.transform.position = new Vector3(this.transform.position.x, floorY_pos + playerHeight/2, this.transform.position.z);
    }
}