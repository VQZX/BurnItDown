using UnityEngine;

namespace Flusk.Extensions
{
    public static class VectorExtensions
    {
        public static float Multiply(this Vector2 v)
        {
            return v.x * v.y;
        }

        public static Vector2 Multiply(this Vector2Int v, float x)
        {
            return new Vector2(v.x * x, v.y * x);
        }
    }
}