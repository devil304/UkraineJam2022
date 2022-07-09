using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager I;

    public static Action OnTimeProgress = delegate { };

    float _time = 0;
    float _timeFromLastPing = 0;
    bool _paused;

    float _pingTime = 2;
    float _pingTimeChange = 0.002f;

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

            if (_timeFromLastPing >= _pingTime)
            {
                _timeFromLastPing = 0;
                _pingTime -= _pingTimeChange; 
                OnTimeProgress?.Invoke();
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
