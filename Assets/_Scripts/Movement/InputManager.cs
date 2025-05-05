using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager _instance;
    
    public InputAction Sprinting { get; private set; }
    public InputAction Ability{get; private set;}
    public InputAction Reloading { get; private set; }
    public bool IsSprinting { get; private set; }

    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private PlayerControls playerControls;

    public void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        playerControls = new PlayerControls();
        playerControls.Enable();
        Cursor.visible = false;

        Sprinting = playerControls.Player.Sprint;
        Ability = playerControls.Player.Ability;
        Reloading = playerControls.Player.Reload;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumpedThisFrame()
    {
        return playerControls.Player.Jump.triggered;
    }

    public bool PlayerSprinting()
    {
        return playerControls.Player.Sprint.triggered;
    }

    public bool PlayerAbilityInUse()
    {
        Debug.Log("F is pressed");
        return playerControls.Player.Ability.triggered;
    }

    public bool PlayerReloading()
    {
        Debug.Log("R is pressed");
        return playerControls.Player.Reload.triggered;
    }
    
}