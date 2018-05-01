using System.Collections.Generic;
using BurnItDown.Environment.Grids;
using Flusk.Utility;
using UnityEngine;

namespace BurnItDown.Environment.Levels
{
    public class LevelBuilderGridCapture : BurnItDownGrid<LevelGridData>
    {
#if UNITY_EDITOR
        public Plane GridPlane { get; set; }
#endif
        
        public Vector2 FirstPosition
        {
            get { return new Vector2(transform.position.x, transform.position.z); }
        }
        
#if UNITY_EDITOR
        public
#else
         private       
#endif
            bool mustDrawCoords;

#if UNITY_EDITOR
        public
#else
        private 
#endif
            void GenerateGrid(Vector2Int gridDimensions, Vector2 blockSize)
        {
            gridData = new List<LevelGridData>();
            // Generate
            for (int i = 0; i < gridDimensions.x; i++)
            {
                for (int j = 0; j < gridDimensions.y; j++)
                {
                    Vector2Int gridPoint = new Vector2Int(i, j);

                    Vector2 gridPointLocal =
                        new Vector2(gridPoint.x * blockSize.x, gridPoint.y * blockSize.y);

                    Vector3 localPosition = transform.position + (Vector3)gridPointLocal + (Vector3)blockSize * 0.5f;
                    LevelGridData levelGridData = new LevelGridData(coordinates: gridPoint, transform: transform, position: localPosition);
                    levelGridData.Size = blockSize.ToVector2Int();
                    gridData.Add(levelGridData);
                    gridPoint.ToString();
                }
            }
        }
    }
}