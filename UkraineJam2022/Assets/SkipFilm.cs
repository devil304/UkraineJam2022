using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipFilm : MonoBehaviour
{
    private void OnEnable()
    {
        InputManager.I.Player1AM.Main.Menu.performed += EndFilm;
        InputManager.I.Player2AM.Main.Menu.performed += EndFilm;
    }

    private void OnDisable()
    {
        InputManager.I.Player1AM.Main.Menu.performed -= EndFilm;
        InputManager.I.Player2AM.Main.Menu.performed -= EndFilm;
    }

    private void EndFilm(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(1);
    }
}
