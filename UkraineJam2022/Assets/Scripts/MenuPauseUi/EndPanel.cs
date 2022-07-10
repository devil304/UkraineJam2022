using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private Player _first;
    [SerializeField] private Player _secend;
    [SerializeField] private TextMeshProUGUI _endTitle;

    public void ShowEndPanel()
    {
        InputManager.I.Player1AM.Main.Disable();
        InputManager.I.Player2AM.Main.Disable();
        if (SecretsEnding.I.SecretEnding)
        {
            _endTitle.text = "Both brothers won!";
        }
        else if (_first.money > 0)
        {
            _endTitle.text = "First brother won!";
        }
        else
        {
            _endTitle.text = "Secend brother won!";
        }

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
