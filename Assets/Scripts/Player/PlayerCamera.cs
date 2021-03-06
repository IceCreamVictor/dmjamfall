﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    ////////////////////////////
    [Header("Looking around")]
    [Tooltip("mouse fucking sensitivity bruh")]
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform playerBody;
    [Tooltip("How low can you look")]
    [SerializeField] private float minXRotate;
    [Tooltip("How high can you look")]
    [SerializeField] private float maxXRotate;
    private float xRotation = 0f;
    ////////////////////////////

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        xRotation = 0f;
    }

    

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime * MenuScript.sens;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime * MenuScript.sens;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minXRotate, maxXRotate);


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    
    
    }
}
