using System.Collections.Generic;
using UnityEngine;

namespace MGSA.Pathing
{
    public class PathController : MonoBehaviour
    {
        public Path path;

        public bool wrapPath;
    
#if UNITY_EDITOR

        public void ForceCheck()
        {
            PointContainer[] containers = GetComponentsInChildren<PointContainer>();
            path.pathPoints = new List<PathPoint>(containers.Length);
            path.pointContainer = new List<PointContainer>();
            foreach (PointContainer container in containers)
            {
                path.pathPoints.Add(container.point);
                path.pointContainer.Add(container);
                container.ForceCheck();
            }
        }
    
        private void OnValidate()
        {
            ForceCheck();
        }
#endif
    }
}