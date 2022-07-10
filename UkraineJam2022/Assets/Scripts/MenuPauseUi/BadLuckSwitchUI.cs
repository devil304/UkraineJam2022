using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadLuckSwitchUI : MonoBehaviour
{
    private float _time = 2;

    [SerializeField] private Player _player1;
    [SerializeField] private Player _player2;

    [SerializeField] private Image _hapy1;
    [SerializeField] private Image _hapy2;

    [SerializeField] private Color32 _sadColor;
    [SerializeField] private Color32 _hapyColor;

    private void OnEnable()
    {
        var is1Sad = _player1.hasBadLuck;
        _hapy1.color = is1Sad ? _sadColor : _hapyColor;
        
        var is2Sad = _player2.hasBadLuck;
        _hapy2.color = is2Sad ? _sadColor : _hapyColor;

        DOVirtual.DelayedCall(0.1f, () => {
            _hapy1.DOColor(is1Sad ? _hapyColor : _sadColor, _time);
            _hapy2.DOColor(is2Sad ? _hapyColor : _sadColor, _time);
        });
        

        DOVirtual.DelayedCall(_time, () => gameObject.SetActive(false));
    }
}
