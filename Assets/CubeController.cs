using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeController : MonoBehaviour
{
    private PlayerControls _playerControls;
    private Vector2 _move;
    private Rigidbody _body;
    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerControls.Player.Moves.performed += Move;
        _playerControls.Player.Moves.Enable();

        _playerControls.Player.Blink.performed += Blink;
        _playerControls.Player.Blink.Enable();
        
        _body = GetComponent<Rigidbody>();
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        Debug.Log($"Move {ctx.ReadValue<Vector2>()}");
        _body.velocity = ctx.ReadValue<Vector2>() * 10f;
    }

    private void Blink(InputAction.CallbackContext ctx)
    {
        Debug.Log("Blink");
        GetComponent<MeshRenderer>().enabled = false;
        Invoke("Return", .1f);
    }

    private void Return()
    {
        GetComponent<MeshRenderer>().enabled = true;
    }
}
