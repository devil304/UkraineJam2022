using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Movement : MonoBehaviour
{

    [SerializeField] float _speed = 2f;

    Rigidbody2D _myRB;

    Vector2 _lastInput;

    // Start is called before the first frame update
    void Start()
    {
        _myRB = GetComponent<Rigidbody2D>();
        InputManager.I.Player2AM.Main.Movement.performed += ProcessInput;
        InputManager.I.Player2AM.Main.Movement.canceled += ProcessInput;
    }

    private void ProcessInput(InputAction.CallbackContext obj)
    {
        _lastInput = obj.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        _myRB.MovePosition(_myRB.position+_lastInput*_speed*Time.deltaTime);
    }
}
