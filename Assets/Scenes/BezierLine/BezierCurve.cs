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

    /// <summary>
    /// 获取指定index点的点坐标
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public Vector3 GetPoint4(float t)
    {
        Vector3 v = Vector3.zero;

        v = transform.TransformPoint(BezierInterface.GetPoint(points[0], points[1], points[2], points[3], t));

        return v;
    }


    /// <summary>
    /// 获取速度 : 向量要的是长度和方向。
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    private Vector3 GetVelocity4(float t)
    {

        Vector3 v, w = Vector3.zero;

        w = BezierInterface.GetFirstDerivative(points[0], points[1], points[2], points[3], t);

        v = transform.TransformPoint(w) - transform.position;

        return v;

    }


    /// <summary>
    /// 获取方向向量
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public Vector3 GetDirection4(float t)
    {
        Vector3 v = GetVelocity4(t);

        return v.normalized;
    }

}
