using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager I;
    public static Action OnBadLackChange = delegate { };

    [SerializeField] private Player _firstPlayer;
    [SerializeField] private Player _secendPlayer;
    [SerializeField] private EndPanel _endPanel;

    private void Awake()
    {
        I = this;
        if (UnityEngine.Random.Range(0, 2) == 0) _firstPlayer.hasBadLuck = true;
        else _secendPlayer.hasBadLuck = true;
    }

    private void OnEnable()
    {
        OnBadLackChange += ChangeLack;
    }

    private void OnDisable()
    {
        OnBadLackChange -= ChangeLack;
    }

    private void ChangeLack()
    {
        _firstPlayer.hasBadLuck = !_firstPlayer.hasBadLuck;
        _secendPlayer.hasBadLuck = !_secendPlayer.hasBadLuck;

        _firstPlayer.goatskin = false;
        _secendPlayer.goatskin = false;
    }

    public void Lose(Player loser)
    {
        TimeManager.I.Pause();
        _endPanel.ShowEndPanel();
    }
}
