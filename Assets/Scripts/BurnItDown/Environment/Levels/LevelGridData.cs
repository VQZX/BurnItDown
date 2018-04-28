using System;
using System.Globalization;
using BurnItDown.Environment.EnvironmentProperty;
using BurnItDown.Environment.Grids;
using MGSA;
using UnityEditor;
using UnityEngine;

namespace BurnItDown.Environment.Levels
{
    public class LevelGridData : IGridData
    {
        public enum Type
        {
            Nothing,
    
            Wood,
            
            Brick   
        }
        
        public Vector2Int Coordinates { get; set; }

        public float Size { get; set; }

        private Vector3 localPosition;
      
        private Transform rootTransform;
        
        // Grid Block Data
        public Type blockType { get; private set; }
        
        public BlockFunctionProperty BlockSecret { get; private set; }
        
        
        public LevelGridData(Vector2Int coordinates)
        {
            Coordinates = coordinates;
        }

        public LevelGridData(Vector2Int coordinates, Transform transform, Vector3 position) : this(coordinates)
        {
            rootTransform = transform;
            localPosition = position;
        }
        
        public Vector2 WorldPoint()
        {
            Vector3 worldPosition = rootTransform.position + localPosition;
            return worldPosition;
        }

        public Vector3 WorldPoint3()
        {
            return rootTransform.position + localPosition;
        }

        public string PrintCoordinates()
        {
            return string.Format("({0}, {1})", Coordinates.x, Coordinates.y);
        }

        public Rect GetRectPoints()
        {
            Rect rect = new Rect();
            rect.center = WorldPoint();

            Vector2 pos = WorldPoint() * Size;

            rect = new Rect(pos, Vector2.one * Size);
            return rect;
        }
      
#if UNITY_EDITOR
        public void DrawEditorData(int id)
        {
            string soilType = blockType.ToString();
            if (GUILayout.Button(soilType))
            {
                CycleType();
            }
            GUIHelper.VerticalGroup(DrawSecetBlock);
        }

        private void DrawSecetBlock()
        {
            GUILayout.Label("Secret Block Function:");
            BlockSecret =
                (BlockFunctionProperty) EditorGUILayout.ObjectField(BlockSecret, typeof(BlockFunctionProperty), false);
        }

        private void CycleType()
        {
            blockType = ++blockType;
            int blockInt = (int) blockType;
            int length = Enum.GetNames(typeof(Type)).Length;
            if (blockInt % length == 0)
            {
                blockType = Type.Nothing;
            }
        }
        
        public void DrawBlock()
        {
            Rect rect = GetRectPoints();
            rect.DrawRect(Color.green);
        }
#endif
    }
}