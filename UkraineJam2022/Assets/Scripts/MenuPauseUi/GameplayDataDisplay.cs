using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayDataDisplay : MonoBehaviour
{
    [SerializeField] Player _player1;
    [SerializeField] Player _player2;

    [SerializeField] GameObject _luckSwitchChange;

    [SerializeField] TextMeshProUGUI _moneyPlayer1;
    [SerializeField] TextMeshProUGUI _badLuckPlayer1;

    [SerializeField] TextMeshProUGUI _moneyPlayer2;
    [SerializeField] TextMeshProUGUI _badLuckPlayer2;

    private void OnEnable()
    {
        _player1.OnPlayerMoneyChange += UpdateMoney;
        _player2.OnPlayerMoneyChange += UpdateMoney;

        GameplayManager.OnBadLackChange += UpdateBadLuck;
    }

    private void OnDisable()
    {
        _player1.OnPlayerMoneyChange -= UpdateMoney;
        _player2.OnPlayerMoneyChange -= UpdateMoney;
        GameplayManager.OnBadLackChange -= UpdateBadLuck;
    }

    private void Start ()
    {
        UpdateMoney();
        DOVirtual.DelayedCall(0.2f, () => {
            _badLuckPlayer1.text = _player1.hasBadLuck ? "Bad luck!" : "";
            _badLuckPlayer2.text = _player2.hasBadLuck ? "Bad luck!" : "";
        });
    }

    private void UpdateBadLuck()
    {
        _luckSwitchChange.SetActive(true);
        DOVirtual.DelayedCall(0.2f, () => {
            _badLuckPlayer1.text = _player1.hasBadLuck ? "Bad luck!" : "";
            _badLuckPlayer2.text = _player2.hasBadLuck ? "Bad luck!" : "";
        });
    }

    private void UpdateMoney()
    {
        _moneyPlayer1.text = _player1.money.ToString();
        _moneyPlayer2.text = _player2.money.ToString();
    }
}
