using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputManager _input;
    private CharacterController _controller;
    
    [SerializeField] private float speed = 5;
    
    void Start()
    {
        
        _input = InputManager.instance;
        _controller = GetComponent<CharacterController>();
        _input.FireAction.performed += FireActionOnperformed;
        _input.SprintAction.performed += SprintActionOnperformed;
        _input.AimAction.performed += AimActionOnperformed;
        _input.FunkyAction.performed += FunkyActionOnperformed;
        _input.ReloadAction.performed += ReloadActionOnperformed;
        _input.AbilityAction.performed += AbilityActionOnperformed;
        _input.JumpAction.performed += JumpActionOnperformed;
    }

    


    #region Buttons
    
    private void ReloadActionOnperformed(InputAction.CallbackContext obj)
    {
        Debug.Log("reload");
    }

    private void JumpActionOnperformed(InputAction.CallbackContext obj)
    {
        
    }
    private void FunkyActionOnperformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Funks");
    }

    private void AimActionOnperformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Aim");
    }

    private void SprintActionOnperformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Run");
    }
    
    private void FireActionOnperformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Shoot");
    }
    private void AbilityActionOnperformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Ability");
    }
    
    #endregion
    
    void Update()
    {
        HandleMovement(Time.deltaTime);
    }

    private void HandleMovement(float delta)
    {
        Vector3 moveDir = (_input.Move.x * transform.right) + (_input.Move.y * transform.forward);
        _controller.Move(moveDir * (speed * delta));
    }
    
}