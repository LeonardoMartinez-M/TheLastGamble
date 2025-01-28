using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private InputManager _input;

    [SerializeField] private Transform playerParent;
    [SerializeField] private float sensitivity = 5;

    private float _xRot;
    
    void Start()
    {
        _input = InputManager.instance;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleLook(Time.deltaTime);
    }

    private void HandleLook(float delta)
    {
        float mouseX = _input.Look.x * delta * sensitivity;
        float mouseY = _input.Look.y * delta * sensitivity;

        _xRot -= mouseY;

        _xRot = Mathf.Clamp(_xRot, -90, 90);

        transform.localRotation = Quaternion.Euler(_xRot, 0, 0);
        
        playerParent.Rotate(Vector3.up, mouseX);
    }
}