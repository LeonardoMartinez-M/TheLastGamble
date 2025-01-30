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
    public InputAction SprintAction { get; private set; }
    public InputAction ReloadAction { get; private set; }
    public InputAction FunkyAction { get; private set; }
    public InputAction AbilityAction { get; private set; }
    public InputAction JumpAction { get; private set; }
    
    public bool FireDown { get; private set; }
    public bool AimDown { get; private set; }
    public bool IsSprinting { get; private set; }
    public bool Reloading { get; private set; }
    public bool FunkyMode { get; private set; }
    public bool AbilityUse { get; private set; }
    public bool Jumping { get; private set; }

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
        SprintAction = _controls.Locomotion.Sprint;
        ReloadAction = _controls.Locomotion.Reload;
        FunkyAction = _controls.Locomotion.Funky;
        AbilityAction = _controls.Locomotion.Ability;
        JumpAction = _controls.Locomotion.Jump;
    }

    
    void Start()
    {
        _controls.Locomotion.Shoot.performed += context => FireDown = true;
        _controls.Locomotion.Shoot.canceled += context => FireDown = false;
        
        _controls.Locomotion.Aim.performed += context => AimDown = true;
        _controls.Locomotion.Aim.canceled += context => AimDown = false;
        
        _controls.Locomotion.Sprint.performed += context => IsSprinting = true;
        _controls.Locomotion.Sprint.canceled += context => IsSprinting = false;

        _controls.Locomotion.Reload.performed += context => Reloading = true;
        _controls.Locomotion.Reload.canceled += context => Reloading = false;
        
        _controls.Locomotion.Funky.performed += context => FunkyMode = true;
        _controls.Locomotion.Funky.canceled += context => FunkyMode = false;
        
        _controls.Locomotion.Ability.performed += context => AbilityUse = true;
        _controls.Locomotion.Ability.canceled += context => AbilityUse = false;

        _controls.Locomotion.Jump.performed += context => Jumping = true;
        _controls.Locomotion.Jump.canceled += context => Jumping = false;
    }

    
    void Update()
    {
        Move = _controls.Locomotion.Move.ReadValue<Vector2>();
        Look = _controls.Locomotion.Look.ReadValue<Vector2>();
    }
}