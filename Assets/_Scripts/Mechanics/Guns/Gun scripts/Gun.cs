using System;
using UnityEngine.Events;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public UnityEvent OnGunReload; // New event for reload
    public UnityEvent OnGunAbility; // New event for 'F' key

    public float FireCooldown;

    public bool Automatic;

    private float CurrentCooldown;

    void Start()
    {
        CurrentCooldown = FireCooldown;
    }

    void Update()
    {
        // Handle Reload (R key)
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnGunReload?.Invoke();
            // You might want to add a reload cooldown or other reload logic here
        }

        // Handle Special Action (F key)
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnGunAbility?.Invoke();
            // Define what the 'F' key does in other scripts listening to OnSpecialAction
        }

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