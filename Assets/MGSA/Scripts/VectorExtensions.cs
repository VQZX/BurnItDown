using UnityEngine;

namespace MGSA
{
     public static class VectorExtensions
     {
          public static Vector3 FlatVector3(this Vector2 vector, float y = 0)
          {
               return new Vector3(vector.x, y, vector.y);
          }

          public static Vector2 ToVector2(this Vector3 v)
          {
               return new Vector2(v.x, v.z);
          }
     
     }
}