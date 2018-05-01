using UnityEngine;

namespace Flusk.Utility
{
    public static class Vector2IntExtensions
    {
        public static Vector3 ToVector3(this Vector2Int v)
        {
            return new Vector3(v.x, v.y, 0);
        }

        public static Vector2 ToVector2(this Vector2Int v)
        {
            return v.ToVector3();
        }

        public static Vector2Int ToVector2Int(this Vector2 v)
        {
            return new Vector2Int((int)v.x, (int)v.y);
        }
    }
}