using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BezierCurve : MonoBehaviour {

    public Vector3[] points;

    //曲线的个数
    public int CurveLength
    {
        get
        {
            return (points.Length - 1) / 3;
        }
    }

    //点的个数
    public int PointCount
    {
        get
        {
            return points.Length;
        }
    }


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
        int i = 0;
        if (t >= 1f)
        {
            i = points.Length - 4;
            t = 1f;
        }
        else
        {
            float n = t * CurveLength;
            i = (int)n;
            t = n - i;
            i *= 3;
        }

        Vector3 v = BezierInterface.GetPoint(points[i], points[i + 1], points[i + 2], points[i + 3], t);
        return transform.TransformPoint(v);
    }


    /// <summary>
    /// 获取速度 : 向量要的是长度和方向。
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    private Vector3 GetVelocity4(float t)
    {

        Vector3 v, w = Vector3.zero;

        int i = 0;
        if (t >= 1f)
        {
            i = points.Length - 4;
            t = 1f;
        }
        else
        {
            float n = t * CurveLength;
            i = (int)n;
            t = n - i;
            i *= 3;
        }
        w = BezierInterface.GetFirstDerivative(points[i], points[i + 1], points[i + 2], points[i + 3], t);

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

    /// <summary>
    /// 添加曲线的points
    /// </summary>
    public void AddCurve()
    {
        Vector3 point = points[points.Length - 1];
        Array.Resize(ref points, points.Length + 3);
        point.x += 1f;
        points[points.Length - 3] = point;
        point.x += 1f;
        points[points.Length - 2] = point;
        point.x += 1f;
        points[points.Length - 1] = point;
    }

}
