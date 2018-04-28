using System.Globalization;
using Grid.Editor;
using MGSA;
using MGSA.Grid;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyGrid))]
public class GridEditor : Editor
{
    private MyGrid grid;

    //private Plane gridPlane;

    private bool isEditingGridBlocks;

    private GridBlock currentGridBlock;

    private Vector2 reworkedClickPoint, lastClickPoint;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        bool generateGrid = GUILayout.Button("Generate Grid");
        if (generateGrid)
        {
            grid.GenerateGrid();
        }

        if (GUILayout.Button(isEditingGridBlocks ? "Switch Off" : "Switch On") )
        {
            isEditingGridBlocks = !isEditingGridBlocks;
        }
        
        EditorUtility.SetDirty(grid);
    }

    private void OnSceneGUI()
    {
        DrawCoordinates();

        ClickingGridBlocks();
        
        SceneView.RepaintAll();
        
        EditorUtility.SetDirty(grid);
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
            if (grid.gridPlane.Raycast(ray, out distance))
            {
                Vector3 hitPoint = ray.GetPoint(distance);
                Debug.Log("Hit Point: "+hitPoint);
                currentGridBlock = grid.Grids.FindClosest(hitPoint);
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

    private void DrawBlock()
    {
        if (currentGridBlock == null)
        {
            return;
        }

        HandlesUtility.HandlesGUI
            (() => DrawBlock(currentGridBlock));
    }

    private void DrawBlock(GridBlock block)
    {
        Vector2 size = new Vector2(200, 100);
        Rect windowRect = new Rect(lastClickPoint, size);
        GUILayout.Window(2, windowRect, (id) =>
            {
                string soilType = block.Data.soiltype.ToString();
                if (GUILayout.Button(soilType))
                {
                    block.Data.CycleSoil();
                }
                
                // Tempetature
                GUIHelper.HorizontalGroup
                (
                    () =>
                    {
                        GUILayout.Label("Temperature:");
                        string temp = GUILayout.TextField(block.Data.Temperature.ToString(CultureInfo.InvariantCulture));
                        float.TryParse(temp, out block.Data.Temperature);
                    }
                );
                
                // Soil Depth
                GUIHelper.HorizontalGroup
                (
                    () =>
                    {
                        GUILayout.Label("Soil Depth:");
                        block.Data.depth = GUILayout.HorizontalSlider(block.Data.depth, 0, 10);
                    }
                );
            },
        block.GetPrettyCoords()
            );
    }

    private void DrawCoordinates()
    {
        if (grid.drawAllCoords)
        {
            foreach (var block in grid.Grids)
            {
                Handles.Label(block.RealWorldPoint, block.GetPrettyCoords());
            }
        }
    }

    private void OnEnable()
    {
        grid = (MyGrid) target;
        grid.gridPlane = new Plane(Vector3.up, grid.transform.position);
    }
}