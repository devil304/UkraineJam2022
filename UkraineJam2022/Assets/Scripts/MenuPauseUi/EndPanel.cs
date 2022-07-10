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
    [SerializeField] private GameObject _win1;
    [SerializeField] private GameObject _win2;
    [SerializeField] private GameObject _winBoth;
    [SerializeField] private AudioSource _win;
    [SerializeField] private AudioSource _lose;

    public void ShowEndPanel()
    {
        InputManager.I.Player1AM.Main.Disable();
        InputManager.I.Player2AM.Main.Disable();
        if (SecretsEnding.I.SecretEnding)
        {
            _endTitle.text = "Both brothers won!";
            _win1.SetActive(false);
            _win2.SetActive(false);
            _winBoth.SetActive(true);
            _lose.Play();
        }
        else if (_first.money > 0)
        {
            _endTitle.text = "First brother won!";
            _win1.SetActive(true);
            _win2.SetActive(false);
            _winBoth.SetActive(false);
            _lose.Play();
        }
        else
        {
            _endTitle.text = "Secend brother won!";
            _win1.SetActive(false);
            _win2.SetActive(true);
            _winBoth.SetActive(false);
            _win.Play();
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
