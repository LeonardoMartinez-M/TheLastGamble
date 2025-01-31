using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputManager _input;
    private CharacterController _controller;

    [SerializeField] private float speed = 5;
    
    void Start()
    {
        _input = InputManager.instance;
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
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