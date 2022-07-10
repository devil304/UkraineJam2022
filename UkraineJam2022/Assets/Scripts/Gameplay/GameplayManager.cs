using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager I;
    public static Action OnBadLackChange = delegate { };

    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private Player _firstPlayer;
    [SerializeField] private Player _secondPlayer;
    [SerializeField] private EndPanel _endPanel;

    private void Awake()
    {
        I = this;
        if (UnityEngine.Random.Range(0, 2) == 0) _firstPlayer.hasBadLuck = true;
        else _secondPlayer.hasBadLuck = true;
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
        _audioSource.Play();
        _firstPlayer.hasBadLuck = !_firstPlayer.hasBadLuck;
        _secondPlayer.hasBadLuck = !_secondPlayer.hasBadLuck;

        _firstPlayer.goatskin = false;
        _secondPlayer.goatskin = false;
    }

    public void Lose(Player loser)
    {
        TimeManager.I.Pause();
        _endPanel.ShowEndPanel();
    }

    void Update()
    {
        if(_firstPlayer.PlayerSR && _secondPlayer.PlayerSR){
            if(_firstPlayer.transform.position.y<_secondPlayer.transform.position.y){
                _firstPlayer.PlayerSR.sortingOrder = 2;
                _secondPlayer.PlayerSR.sortingOrder = 1;
            }else if(_firstPlayer.transform.position.y>_secondPlayer.transform.position.y){
                _firstPlayer.PlayerSR.sortingOrder = 1;
                _secondPlayer.PlayerSR.sortingOrder = 2;
            }
        }
    }
}
