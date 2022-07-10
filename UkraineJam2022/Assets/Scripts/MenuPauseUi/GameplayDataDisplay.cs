using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayDataDisplay : MonoBehaviour
{
    [SerializeField] Player _player1;
    [SerializeField] Player _player2;

    [SerializeField] GameObject _luckSwitchChange;

    [SerializeField] TextMeshProUGUI _moneyPlayer1;
    [SerializeField] Image _badLuckPlayer1;
    [SerializeField] Sprite _hapy1;
    [SerializeField] Sprite _sad1;

    [SerializeField] TextMeshProUGUI _moneyPlayer2;
    [SerializeField] Image _badLuckPlayer2;
    [SerializeField] Sprite _hapy2;
    [SerializeField] Sprite _sad2;

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
            _badLuckPlayer1.sprite = _player1.hasBadLuck ? _sad1 : _hapy1;
            _badLuckPlayer2.sprite = _player2.hasBadLuck ? _sad2 : _hapy2;
        });
    }

    private void UpdateBadLuck()
    {
        _luckSwitchChange.SetActive(true);
        DOVirtual.DelayedCall(0.2f, () => {
            _badLuckPlayer1.sprite = _player1.hasBadLuck ? _sad1 : _hapy1;
            _badLuckPlayer2.sprite = _player2.hasBadLuck ? _sad2 : _hapy2;
        });
    }

    private void UpdateMoney()
    {
        _moneyPlayer1.text = _player1.money.ToString();
        _moneyPlayer2.text = _player2.money.ToString();
    }
}
