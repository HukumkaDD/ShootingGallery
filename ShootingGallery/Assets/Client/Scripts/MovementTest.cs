using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class MovementTest : MonoBehaviour
{
    public Transform p0;
    public Transform p1;
    public Transform p2;
    public Transform p3;

    [Range(0, 1)]
    public float t;

    void Update()
    {
        transform.position = BezierCurve.GetPoint(p0.position, p1.position, p2.position, p3.position, t);
    }

    private void OnDrawGizmos()
    {
        int sigmentNumber = 20;
        Vector3 previousPoint = p0.position;

        for(int i=0; i< sigmentNumber + 1; i++)
        {
            float parameter = (float)i / sigmentNumber;
            Vector3 point = BezierCurve.GetPoint(p0.position, p1.position, p2.position, p3.position, parameter);
            Gizmos.DrawLine(previousPoint, point);
            previousPoint = point;
        }
    }
}
