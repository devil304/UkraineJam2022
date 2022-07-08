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
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            StartPause();
        }
    }

    private void StartPause()
    {
        _pause.SetActive(true);
    }

    public void Resume()
    {
        _pause.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
