using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private GameObject _endPanel;

    public void ShowEndPanel()
    {
        InputManager.I.Player1AM.Main.Disable();
        InputManager.I.Player2AM.Main.Disable();
        _endPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
}
