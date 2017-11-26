using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Line))]
public class LineEditor : Editor {


    Line line;
    Transform lineTransform;
    private void OnEnable()
    {
        line = target as Line;
        lineTransform = line.transform;
    }

    private void OnSceneGUI()
    {
        Handles.color = Color.white;


        //将p0, p1转变成线段的局部坐标，并返回世界坐标。
        Vector3 p0 = lineTransform.TransformPoint(line.p0);
        Vector3 p1 = lineTransform.TransformPoint(line.p1);

        Handles.DrawLine(p0, p1);

        /*
            1获取当前点位置
            2判断点是否发生改变
            3如果发生改变，那么保存改变
        */
        EditorGUI.BeginChangeCheck();
        p0 = Handles.DoPositionHandle(p0, Quaternion.identity);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(line, "Move Point");
            EditorUtility.SetDirty(line);
            line.p0 = lineTransform.InverseTransformPoint(p0);
        }
        EditorGUI.BeginChangeCheck();
        p1 = Handles.DoPositionHandle(p1, Quaternion.identity);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(line, "Move Point");
            EditorUtility.SetDirty(line);
            line.p1 = lineTransform.InverseTransformPoint(p1);
        }


    }

}
