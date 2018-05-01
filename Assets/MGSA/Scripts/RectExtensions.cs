using UnityEditor;
using UnityEngine;

namespace MGSA
{
    public static class RectExtensions
    {
        public static void DrawRect(this Rect rect,  Color color, float yPoint = 0)
        {
            Gizmos.color = color;

            Vector3 bottomLeft = new Vector3(rect.xMin, 0, rect.yMin);
            Vector3 topRight = new Vector3(rect.xMax, 0, rect.yMax);
            Vector3 topLeft = new Vector3(rect.xMin, 0, rect.yMax);
            Vector3 bottomRight = new Vector3(rect.xMax, 0, rect.yMin);
                
            Gizmos.DrawLine(bottomLeft, topLeft);
            Gizmos.DrawLine(topLeft, topRight);
            Gizmos.DrawLine(topRight, bottomRight);
            Gizmos.DrawLine(bottomRight, bottomLeft);
        }
        
#if UNITY_EDITOR
        public static void DrawRectEditor(this Rect rect, Color color)
        {
            Gizmos.color = color;

            Vector3 bottomLeft = new Vector3(rect.xMin, rect.yMin);
            Vector3 topRight = new Vector3(rect.xMax, rect.yMax);
            Vector3 topLeft = new Vector3(rect.xMin, rect.yMax);
            Vector3 bottomRight = new Vector3(rect.xMax, rect.yMin);

            Handles.color = color;
            Handles.DrawLine(bottomLeft, topLeft);
            Handles.DrawLine(topLeft, topRight);
            Handles.DrawLine(topRight, bottomRight);
            Handles.DrawLine(bottomRight, bottomLeft);     
        }
#endif
    }
}