using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
        TimeManager.OnTimeProgress += LoseMoney;
    }

    private void OnDisable()
    {
        TimeManager.OnTimeProgress -= LoseMoney;
    }

    private void LoseMoney()
    {
        if (!hasBadLuck) return;
        money--;
        if (money <= 0)
            GameplayManager.I.Lose(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Money" && !hasBadLuck)
        {
            money++;
            collision.GetComponent<Pickable>().SetRandomPostion();
        }
        else if (collision.tag == "Goatskin" && hasBadLuck)
        {
            goatskin = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!goatskin) return;
        if (collision.gameObject.tag != "Player") return;
        GameplayManager.OnBadLackChange?.Invoke();
    }

}
