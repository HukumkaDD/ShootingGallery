﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BezierCurve
{
    public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        if (t < 0)
            t = 0;
        if (t > 1)
            t = 1f;

        Vector3 p01 = Vector3.Lerp(p0, p1, t);
        Vector3 p12 = Vector3.Lerp(p1, p2, t);
        Vector3 p23 = Vector3.Lerp(p2, p3, t);

        Vector3 p012 = Vector3.Lerp(p01, p12, t);
        Vector3 p123 = Vector3.Lerp(p12, p23, t);

        return Vector3.Lerp(p012, p123, t);
    }

}