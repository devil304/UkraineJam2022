using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

[DefaultExecutionOrder(-100)]
public class InputManager : MonoBehaviour
{
    public static InputManager I;

    Player1 _player1ActionMap;
    Player2 _player2ActionMap;

    public Player1  Player1AM => _player1ActionMap;
    public Player2  Player2AM => _player2ActionMap;

    //[SerializeField] Transform[] _testSquers;

    //Vector2[] _lastMovementVectors = new Vector2[2];
 
    void Awake()
    {
        InputDevice[] _xbox = new InputDevice[2];
        InputDevice _keyboard = null;
        foreach(var device in InputSystem.devices){
            if(device.displayName.ToLower().Contains("keyboard"))
                _keyboard = device;
            else if(device.displayName.ToLower().Contains("xbox") && _xbox.Any(d=>d==null))
                _xbox[_xbox[0]==null?0:1] = device;
        }

        InputSystem.onDeviceChange += DeviceChange;

        _player1ActionMap = new Player1();
        _player1ActionMap.devices = null;
        List<InputDevice> devices = new List<InputDevice>();
        devices.Add(_keyboard);
        if(_xbox[0]!=null)
            devices.Add(_xbox[0]);
        _player1ActionMap.devices = new ReadOnlyArray<InputDevice>(devices.ToArray());
        _player1ActionMap.Enable();
        _player1ActionMap.Main.Enable();
        //Debug.Log($"Player1 devices: {_player1ActionMap.devices.Value.Count}");
        /* _player1ActionMap.Main.Movement.performed += Player1MovementPerformed;
        _player1ActionMap.Main.Movement.canceled += Player1MovementPerformed; */


        _player2ActionMap = new Player2();
        _player2ActionMap.devices = null;
        devices = new List<InputDevice>();
        devices.Add(_keyboard);
        if(_xbox[1]!=null)
            devices.Add(_xbox[1]);
        _player2ActionMap.devices = new ReadOnlyArray<InputDevice>(devices.ToArray());
        _player2ActionMap.Enable();
        _player2ActionMap.Main.Enable();
        //Debug.Log($"Player2 devices: {_player2ActionMap.devices.Value.Count}");
        /* _player2ActionMap.Main.Movement.performed += Player2MovementPerformed;
        _player2ActionMap.Main.Movement.canceled += Player2MovementPerformed; */

        //StartCoroutine(WaitOneFrame());
        I=this;
    }

    void OnDestroy()
    {
        I=null;
    }

    private void DeviceChange(InputDevice device, InputDeviceChange change)
    {
        if(!device.displayName.ToLower().Contains("xbox")) return;
        if((new InputDeviceChange[] {InputDeviceChange.Removed, InputDeviceChange.Disconnected}).Contains(change)){
            var player1Devices = _player1ActionMap.devices.Value.ToList();
            if(player1Devices.Remove(device)){
                _player1ActionMap.devices = new ReadOnlyArray<InputDevice>(player1Devices.ToArray());
                return;
            }

            var player2Devices = _player2ActionMap.devices.Value.ToList();
            if(player2Devices.Remove(device)){
                _player2ActionMap.devices = new ReadOnlyArray<InputDevice>(player2Devices.ToArray());
                return;
            }
        }else if((new InputDeviceChange[] {InputDeviceChange.Added, InputDeviceChange.Reconnected}).Contains(change)){
            if(_player1ActionMap.devices.Value.Count<2){
                var player1Devices = _player1ActionMap.devices.Value.ToList();
                player1Devices.Add(device);
                _player1ActionMap.devices = new ReadOnlyArray<InputDevice>(player1Devices.ToArray());
            }else if(_player2ActionMap.devices.Value.Count<2){
                var player2Devices = _player2ActionMap.devices.Value.ToList();
                player2Devices.Add(device);
                _player2ActionMap.devices = new ReadOnlyArray<InputDevice>(player2Devices.ToArray());
            }
        }
    }

    /* private void Player1MovementPerformed(InputAction.CallbackContext obj)
    {
        _lastMovementVectors[0] = obj.ReadValue<Vector2>();
    }

    private void Player2MovementPerformed(InputAction.CallbackContext obj)
    {
        _lastMovementVectors[1] = obj.ReadValue<Vector2>();
    }

    void Update()
    {
        _testSquers[0].position += (Vector3)_lastMovementVectors[0]*2f*Time.deltaTime;
        _testSquers[1].position += (Vector3)_lastMovementVectors[1]*2f*Time.deltaTime;
    } */
}
