using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(WayPoints))]
public class LineDrawing : Editor
{
    void OnSceneGUI()
    {
        WayPoints line = target as WayPoints;
        Vector3[] points = new Vector3[line.transform.childCount];
        Handles.color = Color.red;
        Transform handleTransform = line.transform;
        for (int i = 0; i <= points.Length - 1; i++)
        {
            points[i] = handleTransform.GetChild(i).position;
        }
        for (int i = 0; i < points.Length; i++)
        {
            Undo.RecordObject(line.transform.GetChild(i), string.Format("Changed position of Waypoint" + (i + 1)));
            if (i != 0)
                Handles.DrawLine(points[i], points[i - 1]);
            Handles.Label(line.transform.GetChild(i).position, "     " + (i + 1));

            EditorGUI.BeginChangeCheck();
            Quaternion upwards = Quaternion.identity;
            Handles.CylinderCap(10200 + i, points[i], upwards, 0.1f);
            line.transform.GetChild(i).position = Handles.PositionHandle(points[i], Quaternion.identity);
        }
    }
}