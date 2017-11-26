
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BezierCurve))]
public class BezierCurveEditor : Editor {

    BezierCurve curve;
    Transform curveTransform;

    const int lineSteps = 10;
    const float directionScale = 0.5f;

    void OnEnable()
    {
        curve = target as BezierCurve;
        curveTransform = curve.transform;
    }

    /// <summary>
    /// 重载Scene UI
    /// </summary>
    void OnSceneGUI()
    {

        Vector3 p0 = ShowPoint(0);
        for (int i = 1; i < curve.PointCount; i += 3)
        {
            Vector3 p1 = ShowPoint(i);
            Vector3 p2 = ShowPoint(i + 1);
            Vector3 p3 = ShowPoint(i + 2);

            Handles.color = Color.gray;
            Handles.DrawLine(p0, p1);
            Handles.DrawLine(p2, p3);

         

            Handles.DrawBezier(p0, p3, p1, p2, Color.white, null, 2f);

            p0 = p3;
        }
        ShowDirection();
    

    }

    /// <summary>
    /// 显示方向
    /// </summary>
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

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Add Curve"))
        {
            Undo.RecordObject(curve, "Add Curve");
            curve.AddCurve();
            EditorUtility.SetDirty(curve);
        }

    }

}
