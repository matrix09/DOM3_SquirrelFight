using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour {

    public Vector3[] points;

    public void Reset()
    {
        points = new Vector3[] { 
            new Vector3(1f, 0f, 0f),
            new Vector3(2f, 0f, 0f),
            new Vector3(3f, 0f, 0f),
            new Vector3 (4f, 0f, 0f)
        };
    }

    public Vector3 GetPoint4(float t)
    {
        Vector3 v = Vector3.zero;

        v = transform.TransformPoint(BezierInterface.GetPoint(points[0], points[1], points[2], points[3], t));

        return v;
    }

    private Vector3 GetVelocity4(float t)
    {

        Vector3 v, w = Vector3.zero;

        w = BezierInterface.GetFirstDerivative(points[0], points[1], points[2], points[3], t);

        v = transform.TransformPoint(w) - transform.position;

        return v;

    }

    public Vector3 GetDirection4(float t)
    {
        Vector3 v = GetVelocity4(t);

        return v.normalized;
    }

}
