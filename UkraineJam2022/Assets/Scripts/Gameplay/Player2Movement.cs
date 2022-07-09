using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Movement : MonoBehaviour
{

    [SerializeField] float _speed = 2f;

    Rigidbody2D _myRB;
    Animator _myAnim;
    Vector2 _lastInput;

    Player _myPlayer;

    [SerializeField] RuntimeAnimatorController _poorAnimator, _richAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _myPlayer = GetComponent<Player>();
        _myAnim = GetComponent<Animator>();
        _myRB = GetComponent<Rigidbody2D>();
        InputManager.I.Player2AM.Main.Horizontal.performed += ProcessInputHorizontal;
        InputManager.I.Player2AM.Main.Horizontal.canceled += ProcessInputHorizontal;
        InputManager.I.Player2AM.Main.Vertical.performed += ProcessInputVertical;
        InputManager.I.Player2AM.Main.Vertical.canceled += ProcessInputVertical;
        //_myAnim.runtimeAnimatorController = _poorAnimator;
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
