using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Movement : MonoBehaviour
{

    [SerializeField] float _speed = 2f;

    Rigidbody2D _myRB;
    Animator _myAnim;
    Vector2 _lastInput;

    Player _myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _myPlayer = GetComponent<Player>();
        _myAnim = GetComponent<Animator>();
        _myRB = GetComponent<Rigidbody2D>();
        InputManager.I.Player1AM.Main.Horizontal.performed += ProcessInputHorizontal;
        InputManager.I.Player1AM.Main.Horizontal.canceled += ProcessInputHorizontal;
        InputManager.I.Player1AM.Main.Vertical.performed += ProcessInputVertical;
        InputManager.I.Player1AM.Main.Vertical.canceled += ProcessInputVertical;
    }

    private void ProcessInputHorizontal(InputAction.CallbackContext obj)
    {
        _lastInput.x = obj.ReadValue<float>();
    }

    private void ProcessInputVertical(InputAction.CallbackContext obj)
    {
        _lastInput.y = obj.ReadValue<float>();
    }

    // Update is called once per frame
    void Update()
    {
        _myAnim.SetFloat("Horizontal",Math.Abs(_lastInput.x));
        if(_lastInput.x<-0.25f && !_myPlayer.PlayerSR.flipX)
            _myPlayer.PlayerSR.flipX = true;
        else if(_lastInput.x>0 && _myPlayer.PlayerSR.flipX)
            _myPlayer.PlayerSR.flipX = false;
        _myAnim.SetFloat("Vertical",_lastInput.y);
        _myRB.MovePosition(_myRB.position+_lastInput*_speed*Time.deltaTime);
    }
}
