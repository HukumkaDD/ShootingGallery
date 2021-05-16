using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBezierCurveBehavior : IMovable
{
    private Vector3[] points;
    private bool isReverse;
    public MoveBezierCurveBehavior(GameObject movementTrajectory)
    {
        points = new Vector3[4];
        for (int i = 0; i < points.Length; i++)
            points[i] = movementTrajectory.transform.GetChild(i).position;

        isReverse = UnityEngine.Random.value > 0.5f;
    }
    public Vector3 StartPoint()
    {
        return isReverse ? points[3] : points[0];
    }
    public Vector3 Move(Vector3 currentPosition, float currentTime)
    {
        if (isReverse)
            return Vector3.MoveTowards(currentPosition, BezierCurve.GetPoint(points[3], points[2], points[1], points[0], currentTime), 1f);
        else
            return Vector3.MoveTowards(currentPosition, BezierCurve.GetPoint(points[0], points[1], points[2], points[3], currentTime), 1f);
    }
}
