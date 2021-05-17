using Game;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MoveBezierCurveBehavior : IMovable
{
    public DeadHandler _nonViolentDeath;
    private Vector3[] _points;
    private bool _isReverse;
    private ITarget _target;
    private float _currentTime = 0;

    public MoveBezierCurveBehavior(ITarget target, DeadHandler nonViolentDeath, GameObject movementTrajectory)
    {
        _target = target;
        _nonViolentDeath = nonViolentDeath;
        _points = new Vector3[4];
        for (int i = 0; i < _points.Length; i++)
            _points[i] = movementTrajectory.transform.GetChild(i).position;

        _isReverse = UnityEngine.Random.value > 0.5f;
    }
    public Vector3 StartPoint(Vector3 currentPosition)
    {
        Vector3 startPoint = _isReverse ? _points[3] : _points[0];
        return new Vector3(startPoint.x, startPoint.y, currentPosition.z);
    }
    public Vector3 Move(Vector3 currentPosition, float speed)
    {
        if (_currentTime > 1)
        {
            EndPoint(_target);
            return currentPosition;
        }
            
        Vector3 bezierCurve = _isReverse
            ? BezierCurve.GetPoint(_points[3], _points[2], _points[1], _points[0], _currentTime)
            : BezierCurve.GetPoint(_points[0], _points[1], _points[2], _points[3], _currentTime);

        _currentTime += speed * Time.deltaTime;

        return Vector3.MoveTowards(currentPosition, new Vector3(bezierCurve.x, bezierCurve.y, currentPosition.z), 1f);
    }

    private void EndPoint(ITarget target)
    {
        _nonViolentDeath.Invoke(target);
    }
}
