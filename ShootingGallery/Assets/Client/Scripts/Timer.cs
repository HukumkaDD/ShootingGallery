using Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer
{
    private readonly float _timer;
    private readonly float _minTime;
    private readonly float _maxTime;
    private readonly bool _isRange;
    private float _currentTimer;

    public float CurrentTime => _currentTimer;

    public TimerHandler DoAction;

    public Timer(TimerHandler doAction, float minTime, float maxTime)
    {
        DoAction = doAction;
        _currentTimer = UnityEngine.Random.Range(_minTime, _maxTime);
        _isRange = true;
        _minTime = minTime;
        _maxTime = maxTime;
    }

    public Timer(TimerHandler doAction, float timer)
    {
        DoAction = doAction;
        _currentTimer = timer;
        _isRange = false;
        _timer = timer;
    }

    public void Update()
    {
        if (_currentTimer > 0)
            _currentTimer -= Time.deltaTime;
        if (_currentTimer <= 0)
        {
            DoAction?.Invoke();
            _currentTimer = _isRange ? UnityEngine.Random.Range(_minTime, _maxTime) : _timer;
        }          
    }
}
