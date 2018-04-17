using System;
using System.Collections.Generic;
using UnityEngine;

namespace MGSA.Pathing
{
    [Serializable]
    public class PathPoint
    {
        public Vector3 point;
    
        public List<PointContainer> children;
    
        [HideInInspector]
        public List<PathPoint> nextPathPoints;

        public bool IsLeaf
        {
            get { return nextPathPoints.Count == 0; }
        }

        public void Validate()
        {
            nextPathPoints = new List<PathPoint>(children.Count);
            foreach (PointContainer point in children)
            {
                nextPathPoints.Add(point.point);
            }
        }
    }
}