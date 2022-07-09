using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static Pause Inst;
    [SerializeField] private GameObject _pause;
    
    private void Awake()
    {
        Inst = this;
        InputManager.I.Player1AM.Main.Menu.performed += StartPause;
        InputManager.I.Player2AM.Main.Menu.performed += StartPause;
    }

    private void StartPause(InputAction.CallbackContext obj)
    {
        InputManager.I.Player1AM.Main.Disable();
        InputManager.I.Player2AM.Main.Disable();
        TimeManager.I.Pause();
        _pause.SetActive(true);
    }

    public void Resume()
    {
        InputManager.I.Player1AM.Main.Enable();
        InputManager.I.Player2AM.Main.Enable();
        _pause.SetActive(false);
        TimeManager.I.UnPause();
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
