using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{

    private float _minTimeSpawn;
    private float _maxTimeSpawn;
    private float _timer;

    public Timer(float minTimeSpawn, float maxTimeSpawn)
    {
        _timer = 0;
        _minTimeSpawn = minTimeSpawn;
        _maxTimeSpawn = maxTimeSpawn;
    }

    void Start()
    {

    }

    void Update()
    {
        if (_timer > 0)
            _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _timer = Random.Range(_minTimeSpawn, _maxTimeSpawn);
        }
    }
}
