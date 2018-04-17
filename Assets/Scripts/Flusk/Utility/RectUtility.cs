using UnityEngine;

namespace Flusk.Utility
{
    public static class RectUtility
    {
        public static void DrawRect(this Rect rect)
        {
            Vector3 bottomLeft = (Vector3) rect.min;
            Vector3 topRight = (Vector3) rect.max;
            Vector3 bottomRight = new Vector3(topRight.x, bottomLeft.y);
            Vector3 topLeft = new Vector3(bottomLeft.x, topRight.y);
            
            Gizmos.DrawLine(bottomLeft, bottomRight);
            Gizmos.DrawLine(bottomRight, topRight);
            Gizmos.DrawLine(topRight,  topLeft);
            Gizmos.DrawLine(topLeft, bottomLeft);
        }
    }
}