using System.Collections.Generic;
using BurnItDown.Environment.Grids;
using Flusk.Utility;
using UnityEngine;

namespace BurnItDown.Environment.Levels
{
    public class LevelBuilderGridCapture : BurnItDownGrid<LevelGridData>
    {
        
        class PathNames
        {
            public const string WOOD_PATH = "wood_edit";
            public const string ROOF_PATH = "roof_edit";
        }
        
        
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

            Texture woodEdit = Resources.Load<Texture>(PathNames.WOOD_PATH);
            Texture roofEdit = Resources.Load<Texture>(PathNames.ROOF_PATH);
            
            // Generate
            for (int i = 0; i < gridDimensions.x; i++)
            {
                for (int j = 0; j < gridDimensions.y; j++)
                {
                    Vector2Int gridPoint = new Vector2Int(i, j);

                    Vector2 gridPointLocal =
                        new Vector2(gridPoint.x * blockSize.x, gridPoint.y * blockSize.y);

                    Vector3 localPosition = (Vector3)gridPointLocal + (Vector3)blockSize * 0.5f;
                    LevelGridData levelGridData = new LevelGridData(coordinates: gridPoint, transform: transform, position: localPosition);
                    levelGridData.Size = blockSize.ToVector2Int();
                    gridData.Add(levelGridData);
                    
#if UNITY_EDITOR
                    levelGridData.woodTexture = woodEdit;
                    levelGridData.roofTexture = roofEdit;
#endif
                }
            }
        }
        
#if UNITY_EDITOR
        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            if (gridData == null || gridData.Count == 0)
            {
                return;
            }
        
            foreach (LevelGridData block in gridData)
            {
                Rect rect = block.GetRectPoints();
                Texture texture = block.GetTextureToDraw();
                if (texture == null)
                {
                    return;
                }
                Gizmos.DrawGUITexture(rect, texture);
            }
        }
#endif
    }
}