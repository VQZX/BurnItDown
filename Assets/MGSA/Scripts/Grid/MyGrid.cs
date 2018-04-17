using System;
using UnityEngine;

namespace MGSA.Grid
{
    [Serializable]
    public class MyGrid : MonoBehaviour
    {
        public float GridBlockSize;

        public bool drawAllCoords;

        /// <summary>
        /// In grid space
        /// </summary>
        public Vector2Int GridDimensions;

        [SerializeField]
        public Grids Grids;

        public new BoxCollider collider;

        public Plane gridPlane;

        public Transform Transform
        {
            get { return transform; }
        }

        public Vector2 FirstPosition
        {
            get { return new Vector2(transform.position.x, transform.position.z) / GridBlockSize; }
        }

        public void GenerateGrid()
        {
            Grids = new Grids(GridDimensions.x * GridDimensions.y);
            collider = GetComponent<BoxCollider>();
            if (collider == null)
            {
                collider = gameObject.AddComponent<BoxCollider>();
            }
            // Generate
            for (int i = 0; i < GridDimensions.x; i++)
            {
                for (int j = 0; j < GridDimensions.y; j++)
                {
                    Vector2 gridPoint = new Vector2(i, j) + FirstPosition;
                    GridBlock gridBlock = new GridBlock(grid: this, position: gridPoint,
                        gridPosition: new Vector2Int(i, j), size: GridBlockSize);
                    Grids.Add(gridBlock);
                }
            }
        
            // Set the collider
            collider.size = new Vector3(GridDimensions.x * GridBlockSize, 0, GridDimensions.y * GridBlockSize);
            collider.center = collider.size * 0.5f;
        }
    
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (Grids == null)
            {
                return;
            }
        
            foreach (GridBlock block in Grids)
            {
                block.DrawBlock(elevation: transform.position.y);
            }
        }
#endif
    }
}