using
System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BezierCurve))]
public class BezierCurveEditor : Editor {

    BezierCurve curve;
    Transform curveTransform;


    void OnEnable()
    {
        curve = target as BezierCurve;
        curveTransform = curve.transform;
    }

    void OnSceneGUI()
    {

        Vector3 p0 = ShowPoint(0);
        Vector3 p1 = ShowPoint(1);
        Vector3 p2 = ShowPoint(2);
        Vector3 p3 = ShowPoint(3);

        Handles.color = Color.gray;
        Handles.DrawLine(p0, p1);
        Handles.DrawLine(p2, p3);

        ShowDirection();

        Handles.DrawBezier(p0, p3, p1, p2, Color.white, null, 2f);

    }

    const int lineSteps = 10;
    const float directionScale = 0.5f;
    void ShowDirection()
    {
        Handles.color = Color.green;
        for (int i = 0; i < lineSteps; i++)
        {
            Vector3 point = curve.GetPoint4((float)i / (float)lineSteps);
            Handles.DrawLine(point, point + curve.GetDirection4((float)i / (float)lineSteps) * directionScale);
        }

    }

    /// <summary>
    /// 获取指定index点的世界坐标
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    Vector3 ShowPoint(int index)
    {
        Vector3 point = curveTransform.TransformPoint(curve.points[index]);

        EditorGUI.BeginChangeCheck();
        
        point = Handles.DoPositionHandle(point, Quaternion.identity);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(curve, "move point");
            EditorUtility.SetDirty(curve);
            curve.points[index] = curveTransform.InverseTransformPoint(point);
        }

        return point;

    }

}
