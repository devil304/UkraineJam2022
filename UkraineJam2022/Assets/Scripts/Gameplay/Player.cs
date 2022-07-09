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
    public int money = 100;

    SpriteRenderer _mySR;

    public SpriteRenderer PlayerSR => _mySR;

    void Start()
    {
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

    private void LoseMoney()
    {
        if (!hasBadLuck) return;
        money--;
        OnPlayerMoneyChange?.Invoke();
        if (money <= 0)
            GameplayManager.I.Lose(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!goatskin) return;
        if (collision.gameObject.tag != "Player") return;
        GameplayManager.OnBadLackChange?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Money" && !hasBadLuck)
        {
            money++;
            OnPlayerMoneyChange?.Invoke();
            collision.transform.GetComponent<Pickable>().Pickup();
        }
        else if (collision.gameObject.tag == "Goatskin" && hasBadLuck)
        {
            goatskin = true;
            collision.transform.GetComponent<Pickable>().Pickup();
        }
    }

}
