using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager I;

    public static Action OnTimeProgressMoney = delegate { };
    public static Action OnGoastProgress = delegate { };

    public float GameTime => _time;
    float _time = 0;
    float _timeFromLastMoney = 0;
    float _timeFromGoast = 0;
    bool _paused;

    float _moneyTime = 1;
    float _goatTime = 90;

    void Awake()
    {
        I = this;
    }

    void Update()
    {
        if (!_paused)
        {
            _time += Time.deltaTime;
            _timeFromLastMoney += Time.deltaTime;
            _timeFromGoast += Time.deltaTime;

            if(_timeFromLastMoney >= _moneyTime)
            {
                _timeFromLastMoney = 0;
                OnTimeProgressMoney?.Invoke();
            }
            if (_timeFromGoast >= _goatTime)
            {
                _timeFromGoast = 0;
                OnGoastProgress?.Invoke();
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
