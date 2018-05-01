using System;
using System.Collections.Generic;
using BurnItDown.Environment.Grids;
using Grid.Editor;
using UnityEditor;
using UnityEngine;

namespace BurnItDown.Environment.Levels.Editor
{
    [CustomEditor(typeof(LevelBuilderGridCapture))]
    public class LevelBuilderGridCaptureEditor : UnityEditor.Editor
    {
        class PropertyNames
        {
            // Level Builder
            public const string GRID_SIZE = "gridSize";
            public const string BLOCK_SIZE = "blockSize";
        }
        
        
        private LevelBuilderGridCapture capture;
        private bool isEditingGridBlocks;
        private LevelGridData currentGridBlock;
        private Vector2 reworkedClickPoint, lastClickPoint;

        private SerializedProperty gridDataProperty;
        private List<LevelGridData> gridData;

        private LevelBuilder levelBuilder;
        private SerializedObject levelBuilderObject;
        private Vector2Int gridSize, blockSize;
        private SerializedProperty gridSizeProperty, blockSizeProperty;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            if (GUILayout.Button("Generate"))
            {
                capture.GenerateGrid(gridSize, blockSize); 
            }
        }

        private void OnSceneGUI()
        {
            if (capture.mustDrawCoords)
            {
                DrawCoordinates();
            }
            ClickingGridBlocks();
        }


        private void OnValidate()
        {
            InitData();
        }

        private void OnEnable()
        {
            InitData();
        }

        private void InitData()
        {
            capture = (LevelBuilderGridCapture) target;
            levelBuilder = capture.GetComponent<LevelBuilder>();
            levelBuilderObject = new SerializedObject(levelBuilder);

            gridSizeProperty = levelBuilderObject.FindProperty(PropertyNames.GRID_SIZE);
            gridSize = gridSizeProperty.vector2IntValue;

            blockSizeProperty = levelBuilderObject.FindProperty(PropertyNames.BLOCK_SIZE);
            blockSize = blockSizeProperty.vector2IntValue;
        }
        
        private void DrawCoordinates()
        {
            if (capture.mustDrawCoords)
            {
                foreach (LevelGridData block in capture.gridData)
                {
                    Handles.Label(block.WorldPoint(), block.PrintCoordinates());
                }
            }
        }
        
        private void ClickingGridBlocks()
        {
            if (Event.current.type == EventType.MouseDown && Event.current.button == 1)
            {
                Camera current = GetSceneCamera();
                if (current == null)
                {
                    return;
                }
                lastClickPoint = Event.current.mousePosition;
                reworkedClickPoint = lastClickPoint;
                reworkedClickPoint.y = SceneView.currentDrawingSceneView.position.height - lastClickPoint.y;
                Ray ray = current.ScreenPointToRay(reworkedClickPoint);
                float distance;
                if (capture.GridPlane.Raycast(ray, out distance))
                {
                    Vector3 hitPoint = ray.GetPoint(distance);
                    Debug.Log("Hit Point: "+hitPoint);
                    currentGridBlock = (LevelGridData)capture.FindClosest(hitPoint);
                }
                else
                {
                    currentGridBlock = null;
                }
                Event.current.Use();
            }
            else if ( Event.current.type == EventType.MouseDown && Event.current.button == 0)
            {
                currentGridBlock = null;
            }
            DrawBlock();
        }
        
        private void DrawBlock()
        {
            if (currentGridBlock == null)
            {
                return;
            }

            HandlesUtility.HandlesGUI
                (() => DrawBlock(currentGridBlock));
        }

        private void DrawBlock(IGridData block)
        {
            Vector2 size = new Vector2(200, 100);
            Rect windowRect = new Rect(lastClickPoint, size);            
            GUILayout.Window(2, windowRect, block.DrawEditorData, block.PrintCoordinates());
        }

        private Camera GetSceneCamera()
        {
            Camera [] camera = SceneView.GetAllSceneCameras();
            foreach (var cam in camera)
            {
                if (cam.cameraType == CameraType.SceneView)
                {
                    return cam;
                }
            }
            return null;
        }
    }
}