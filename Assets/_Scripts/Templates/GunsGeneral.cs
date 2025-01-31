using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public abstract class GunsGeneral : MonoBehaviour
{
    protected bool Active;
    [SerializeField] protected int Damage;
    [SerializeField] protected int ADSSway;
    [SerializeField] protected int Sway;
    [SerializeField] protected int Recoil;

    private InputManager _input;
    private void Awake()
    {
        _input = InputManager.instance;
        Active = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Active == true)
        {
            return;
        }
        
        }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void ApplyEffect();
}
