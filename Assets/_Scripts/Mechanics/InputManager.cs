using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    private Controls _controls;
    
    public Vector2 Move { get; private set;}
    public Vector2 Look { get; private set; }
    
    public InputAction FireAction { get; private set; }
    public InputAction AimAction { get; private set; }
    
    public bool FireDown { get; private set; }
    public bool AimDown { get; private set; }

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        _controls = new Controls();
        _controls.Enable();
        
        FireAction = _controls.Locomotion.Shoot;
        AimAction = _controls.Locomotion.Aim;
    }

    
    void Start()
    {
        _controls.Locomotion.Shoot.performed += context => FireDown = true;
        _controls.Locomotion.Shoot.canceled += context => FireDown = false;
        
        _controls.Locomotion.Aim.performed += context => AimDown = true;
        _controls.Locomotion.Aim.canceled += context => AimDown = false;
    }

    
    void Update()
    {
        Move = _controls.Locomotion.Move.ReadValue<Vector2>();
        Look = _controls.Locomotion.Look.ReadValue<Vector2>();
    }
}