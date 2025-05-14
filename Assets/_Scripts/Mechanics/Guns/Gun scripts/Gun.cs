using System;
using _Scripts.Mechanics.Guns.Bones;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public GunDisplay guns;
    public UnityEvent OnGunShoot;
    public UnityEvent OnGunReload; // New event for reload
    public UnityEvent OnGunAbility; // New event for 'F' key

    private float FireCooldown;

    public bool Automatic;

    public float CurrentCooldown;

    private InputManager input;


    private void OnValidate()
    {
        FireCooldown = (float)guns.gun.fireRate;
        if (CurrentCooldown!=FireCooldown)
        {
            CurrentCooldown = FireCooldown;
        }
    }

    void Start()
    {
        CurrentCooldown = FireCooldown;
        input = InputManager._instance;
        
        input.Reloading.performed += ReloadingOnperformed;
        input.Ability.performed += AbilityOnperformed;
    }

    private void AbilityOnperformed(InputAction.CallbackContext obj)
    { 
        OnGunAbility?.Invoke();
    }

    private void ReloadingOnperformed(InputAction.CallbackContext obj)
    {
       OnGunReload?.Invoke();
    }

    void Update()
    {
        // Handle Shooting (Left Mouse Button)
        if (Automatic)
        {
            if (Input.GetMouseButton(0))
            {
                if (CurrentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0)) // Use GetMouseButtonDown for single shots
            {
                if (CurrentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                }
            }
        }

        CurrentCooldown -= Time.deltaTime;
    }
}