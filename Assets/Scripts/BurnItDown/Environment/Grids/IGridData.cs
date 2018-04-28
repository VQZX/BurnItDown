using UnityEngine;

namespace BurnItDown.Environment.Grids
{
    /// <summary>
    /// Base class for individual grid info
    /// </summary>
    public interface IGridData
    {
        Vector2Int Coordinates { get; set; }
        float Size { get; set; }

        Vector2 WorldPoint();
        Vector3 WorldPoint3();
        string PrintCoordinates();
        void DrawBlock();
        
#if UNITY_EDITOR
        void DrawEditorData(int id);
#endif
    }
}