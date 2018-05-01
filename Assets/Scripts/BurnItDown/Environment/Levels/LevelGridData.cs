using System;
using System.Globalization;
using System.Runtime.Serialization;
using BurnItDown.Environment.EnvironmentProperty;
using BurnItDown.Environment.Grids;
using MGSA;
using UnityEditor;
using UnityEngine;

namespace BurnItDown.Environment.Levels
{
    [Serializable]
    public class LevelGridData : IGridData, ISerializable
    {
        public enum Type
        {
            Nothing,
    
            Wood,
            
            Brick   
        }

        [SerializeField]
        private Vector2Int coordinates;
        public Vector2Int Coordinates
        {
            get { return coordinates; }
            set { coordinates = value; }
        }

        [SerializeField]
        private Vector2Int size;
        public Vector2Int Size
        {
            get { return size; }
            set { size = value; }
        }

        [SerializeField]
        private Vector3 localPosition;
      
        [SerializeField]
        private Transform rootTransform;
        
        // Grid Block Data
        [SerializeField]
        private Type blockType;

        public Type BlockType
        {
            get { return blockType; }
            private set { blockType = value; }
        }

        [SerializeField]
        private BlockFunctionProperty blockSecret;
        public BlockFunctionProperty BlockSecret
        {
            get { return blockSecret; }
            private set { blockSecret = value; }
        }        
        public LevelGridData(Vector2Int coordinates)
        {
            Coordinates = coordinates;
        }

        public LevelGridData(Vector2Int coordinates, Transform transform, Vector3 position) : this(coordinates)
        {
            rootTransform = transform;
            localPosition = position;
        }

        public LevelGridData(SerializationInfo info, StreamingContext context)
        {
            coordinates = (Vector2Int) info.GetValue("coordinates", typeof(Vector2Int));
            size = (Vector2Int) info.GetValue("coordinates", typeof(Vector2Int));
            localPosition = (Vector3) info.GetValue("coordinates", typeof(Vector3));
            rootTransform = (Transform) info.GetValue("coordinates", typeof(Transform));
            blockType = (Type) info.GetValue("coordinates", typeof(Type));
            blockSecret = (BlockFunctionProperty) info.GetValue("coordinates", typeof(BlockFunctionProperty));
        }
        
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("coordinates", coordinates, typeof(Vector2Int));
            info.AddValue("size", size, typeof(Vector2Int));
            info.AddValue("localPosition", localPosition, typeof(Vector3));
            info.AddValue("rootTransform", rootTransform, typeof(Transform));
            info.AddValue("blockType", blockType, typeof(Type));
            info.AddValue("blockSecret", blockSecret, typeof(BlockFunctionProperty));
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

            Vector2 pos = WorldPoint() + Size;

            rect = new Rect(pos, Size);
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
            rect.DrawRectEditor(Color.green);
        }

        public void DrawBlockEditor()
        {
            Rect rect = GetRectPoints();
            rect.DrawRectEditor(Color.green);
        }
#endif
    }
}