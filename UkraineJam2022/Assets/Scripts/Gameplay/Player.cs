using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool hasBadLuck;
    public bool goatskin;
    public int money = 100;

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
        money--;
        if (money <= 0)
            GameplayManager.I.Lose(this);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Money")
        {
            money++;
        }
        if (collision.tag == "Goatskin")
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
