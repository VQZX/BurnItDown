using System;
using UnityEngine;

namespace MGSA.Grid
{
    [Serializable]
    public class GridBlock
    {
        public Vector2 Position;

        public Vector2Int gridPoint;

        public float Size;

        public MyGrid ParentGrid;

        [SerializeField]
        public GridData Data;

        public Vector3 RealWorldPoint
        {
            get { return GetRealWorldPosition(); }
        }

        public Vector3 GetRealWorldPosition()
        {
            Vector2 center = GetRectPoints().center;
            Vector3 parentPosition = ParentGrid.transform.position;
            return new Vector3(center.x, parentPosition.y, center.y);
        }

        public GridBlock()
        {
            Position = new Vector2();
            Size = 1;
        }

        public string GetPrettyCoords()
        {
            return string.Format("({0}, {1})", gridPoint.x, gridPoint.y);
        }

        public GridBlock(MyGrid grid, Vector2 position, Vector2Int gridPosition, float size)
        {
            ParentGrid = grid;
            Position = position;
            gridPoint = gridPosition;
            Size = size;
        }
    
        public Rect GetRectPoints()
        {
            Rect rect = new Rect();
            rect.center = Position;

            Vector2 pos = Position * Size;

            rect = new Rect(pos, Vector2.one * Size);
            return rect;
        }

        public void DrawBlock(float elevation)
        {
            Rect rect = GetRectPoints();
            rect.DrawRect(Color.green, elevation);
        }
    
    }
}