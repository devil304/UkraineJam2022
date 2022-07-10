using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action OnPlayerMoneyChange = delegate { };
    public bool hasBadLuck;
    public bool goatskin;
    public bool goast;
    public int money = 100;
    private bool _playedMoneyLow = false;

    bool rich = true;

    SpriteRenderer _mySR;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] RuntimeAnimatorController[] _animators;
    [SerializeField] Player _anotherPlayer;

    public SpriteRenderer PlayerSR => _mySR;

    Animator _myAnim;

    void Start()
    {
        _myAnim = GetComponent<Animator>();
        _myAnim.runtimeAnimatorController = _animators[0];
        _mySR = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        TimeManager.OnTimeProgressMoney += LoseMoney;
    }

    private void OnDisable()
    {
        TimeManager.OnTimeProgressMoney -= LoseMoney;
    }

    void Update()
    {
        if(money<_anotherPlayer.money && rich){
            rich = false;
            _myAnim.runtimeAnimatorController = _animators[1];
        }else if(money>_anotherPlayer.money && !rich){
            rich = true;
            _myAnim.runtimeAnimatorController = _animators[0];
        }
    }

    private void LoseMoney()
    {
        if (!hasBadLuck) return;
        var time = TimeManager.I.GameTime;

        if (time < 120)
            money--;
        else if (time < 180)
            money = money - 2;
        else if (time < 240)
            money = money - 3;
        else if (time < 300)
            money = money - 4;
        else if (time < 360)
            money = money - 5;
        else if (time < 420)
            money = money - 6;
        else if (time < 480)
            money = money - 7;
        else if (time < 540)
            money = money - 8;
        else if (time < 600)
            money = money - 9;
        else
            money = money - 10;

        OnPlayerMoneyChange?.Invoke();

        if (money <= 40)
        {
            if(!_playedMoneyLow)
            {
                _playedMoneyLow = true;
                _audioSource.Play();
            }
            SecretsEnding.I.SecretsEndingEnable = true;
        }

        if (money <= 0)
            GameplayManager.I.Lose(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Goast" && !hasBadLuck)
        {
            goast = true;
            DOVirtual.DelayedCall(8, () => goast = false);
            collision.transform.GetComponent<Pickable>().Pickup();
        }

        if (!goatskin) return;
        if (collision.gameObject.tag != "Player") return;

        if (SecretsEnding.I.SecretsEndingGoatskinProgress)
            SecretsEnding.I.HappyEnd();
        else
            GameplayManager.OnBadLackChange?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Money" && !hasBadLuck)
        {
            if (goast)
                money += 2;
            else
                money++;
            OnPlayerMoneyChange?.Invoke();
            collision.transform.GetComponent<Pickable>().Pickup();
        }
        else if (collision.gameObject.tag == "Goatskin" && hasBadLuck)
        {
            goatskin = true;
            collision.transform.GetComponent<Pickable>().Pickup();
        }
        else if (collision.gameObject.tag == "Goatskin" && !hasBadLuck && SecretsEnding.I.SecretsEndingEnable)
        {
            goatskin = true;
            collision.transform.GetComponent<Pickable>().Pickup();
            SecretsEnding.I.SecretsEndingGoatskinProgress = true;
        }
    }

}
