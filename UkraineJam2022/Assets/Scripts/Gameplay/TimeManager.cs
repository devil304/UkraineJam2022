using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager I;

    public static Action OnTimeProgressPing = delegate { };
    public static Action OnTimeProgressMoney = delegate { };

    float _time = 0;
    float _timeFromLastPing = 0;
    float _timeFromLastMoney = 0;
    bool _paused;

    float _pingTime = 2;
    float _moneyTime = 5;
    float _moneyTimeChange = 0.02f;
    float _pingTimeChange = 0.005f;

    void Awake()
    {
        I = this;
    }

    void Update()
    {
        if (!_paused)
        {
            _time += Time.deltaTime;
            _timeFromLastPing += Time.deltaTime;
            _timeFromLastMoney += Time.deltaTime;

            if (_timeFromLastPing >= _pingTime)
            {
                _timeFromLastPing = 0;
                _pingTime -= _pingTimeChange; 
                OnTimeProgressPing?.Invoke();
            }

            if(_timeFromLastMoney >= _moneyTime)
            {
                _timeFromLastMoney = 0;
                _moneyTime -= _moneyTimeChange;
                OnTimeProgressMoney?.Invoke();
            }

        }
    }

    public void Pause()
    {
        _paused = true;
    }

    public void UnPause()
    {
        _paused = false;
    }

    void OnDestroy()
    {
        I = null;
    }
}
