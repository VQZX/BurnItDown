using System;
using System.Collections.Generic;

namespace MGSA.Pathing
{
    [Serializable]
    public class Path
    {
        public List<PathPoint> pathPoints;

        public List<PointContainer> pointContainer;

        public PathPoint First
        {
            get { return pathPoints[0]; }
        }

        public PointContainer FirstContainer
        {
            get { return pointContainer[0]; }
        }
    
    }
}