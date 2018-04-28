using BurnItDown.Environment.Grids;
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
            void GenerateGrid(Vector2Int gridDimensions)
        {
            // Generate
            for (int i = 0; i < gridDimensions.x; i++)
            {
                for (int j = 0; j < gridDimensions.y; j++)
                {
                    Vector2 gridPoint = new Vector2(i, j) + FirstPosition;
                    //GridBlock gridBlock = new GridBlock(grid: grid, position: gridPoint,
                        //gridPosition: new Vector2Int(i, j), size: gridBlockSize.x);
                    //grid.Grids.Add(gridBlock);
                }
            }
        }
    }
}