using MGSA.Grid;
using UnityEngine;

namespace BurnItDown.Environment.Levels
{
    public class LevelBuilderGridCapture : BurnItDownBehaviour
    {
        [SerializeField]
        protected Vector2 gridBlockSize = new Vector2(1,1);

        [SerializeField]
        protected bool drawCoords;

        [SerializeField]
        protected Vector2Int gridDimensions;

        [SerializeField]
        protected MyGrid grid;

        private new BoxCollider collider;
        
        public Vector2 FirstPosition
        {
            get { return new Vector2(transform.position.x, transform.position.z) / gridBlockSize.x; }
        }
        
        [SerializeField]
        protected MGSA.Grid.Grids grids;

        public void GenerateGrid()
        {
            grid.Grids = new MGSA.Grid.Grids(gridDimensions.x * gridDimensions.y);
            collider = GetComponent<BoxCollider>();
            if (collider == null)
            {
                collider = gameObject.AddComponent<BoxCollider>();
            }

            // Generate
            for (int i = 0; i < gridDimensions.x; i++)
            {
                for (int j = 0; j < gridDimensions.y; j++)
                {
                    Vector2 gridPoint = new Vector2(i, j) + FirstPosition;
                    GridBlock gridBlock = new GridBlock(grid: grid, position: gridPoint,
                        gridPosition: new Vector2Int(i, j), size: gridBlockSize.x);
                    grid.Grids.Add(gridBlock);
                }
            }
        }
    }
}