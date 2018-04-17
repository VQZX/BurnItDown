using System;
using System.Collections.Generic;
using UnityEngine;

namespace MGSA.AreaMesh
{
   [Serializable]
   public class Area
   {
      [SerializeField]
      public List<Vector3> meshPoints;

      [SerializeField]
      protected Mesh savedMesh;

      public Mesh SavedMesh
      {
         get { return savedMesh; }
      }
    
      public Triangulator Triangulator { get; private set; }
  

      public void Save(string meshName = "Default Mesh Name")
      {
         List<Vector2> trianglePoints = new List<Vector2>(this.meshPoints.Count);
         foreach (var point in meshPoints)
         {
            trianglePoints.Add(new Vector2(point.x, point.z));
         }
         Triangulator = new Triangulator(trianglePoints.ToArray());

         savedMesh = new Mesh
         {
            name = meshName,
            vertices = meshPoints.ToArray(),
            triangles = Triangulator.Triangulate()
         };
         savedMesh.RecalculateNormals();
         savedMesh.RecalculateBounds();
      }
   
   }
}