using System;
using System.Collections.Generic;
using BurnItDown.Environment.Grids;
using Flusk.Extensions;
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


        private Vector2 gridDimensions;

        private LevelBuilder builder;
        
#if UNITY_EDITOR
        public
#else
         private       
#endif
            bool mustDrawCoords;

        [SerializeField]
        protected bool drawGUITexture;

#if UNITY_EDITOR
        public
#else
        private 
#endif
            void GenerateGrid(Vector2Int gridDimensions, Vector2 blockSize)
        {
            gridData = new List<LevelGridData>();
            this.gridDimensions = gridDimensions;
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

        public LevelGridData GetGridData(int i, int j)
        {
            if (Math.Abs(gridDimensions.Multiply()) <= float.Epsilon)
            {
                if (builder == null)
                {
                    builder = GetComponent<LevelBuilder>();
                }

                gridDimensions = builder.GridSize;
            }
            
            int index = i * (int) gridDimensions.y + j;
            var data =  gridData[index];
            return data;
        }
        
        
#if UNITY_EDITOR
        protected override void OnDrawGizmosSelected()
        {
            //base.OnDrawGizmosSelected();

            if (!drawGUITexture)
            {
                return;
            }
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
                    continue;
                }
                Gizmos.DrawGUITexture(rect, texture);
            }
        }
#endif
    }
}