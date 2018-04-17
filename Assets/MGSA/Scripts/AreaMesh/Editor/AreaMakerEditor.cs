using System;
using System.Collections.Generic;
using MGSA.AreaMesh;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AreaMaker))]
public class AreaMakerEditor : Editor
{
    private AreaMaker areaMaker;

    private Area area
    {
        get { return areaMaker.area; }
    }

    private bool IsEditingMesh
    {
        get { return areaMaker.isEditing; }
        set { areaMaker.isEditing = value; }
    }
    private Camera mainCamera;

    private const float MINIMUM_CLICK_DISTANCE = 0.5f;
    private const float DEFAULT_SIZE = 10.0f;

    private Plane templatePlane;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        bool toggleMeshEditor = GUILayout.Button("Toggle Mesh Editor");
        if (toggleMeshEditor)
        {
            // When toggling back to "not editing" save the points
            if (IsEditingMesh)
            {
                Save();
            } 
            IsEditingMesh = !IsEditingMesh;
        }

        if (IsEditingMesh)
        {
            DrawDefaultOptions();
        }
        
        EditorUtility.SetDirty(areaMaker);
    }
    
    private void OnSceneGUI()
    {
        if (IsEditingMesh)
        {
            EditMesh();
        }
        
        if (Selected())
        {
            if (IsEditingMesh)
            {
                DrawEditHandles();
            }
            else
            {
                DrawHandles();
            }
        }
    }

    private void Save()
    {
        areaMaker.Save();
    }

    private void DrawDefaultOptions()
    {
        GUILayout.Space(5f);
        GUILayout.Label("Default Configurations");

        bool createSquare = GUILayout.Button("Create Square");
        if (createSquare)
        {
            CreateSquare();
        }

        bool createOctagon = GUILayout.Button("Create Octagon");
        if (createOctagon)
        {
            CreateOctagon();
        }
    }

    private void CreateSquare()
    {
        CreatePolygon(4);
    }
    
    private void CreateOctagon()
    {
        CreatePolygon(8);
    }

    private void CreatePolygon(int sides)
    {
        float angle = 360 / (float)sides;
        Vector3 center = areaMaker.transform.position;
        area.meshPoints = new List<Vector3>(sides);
        
        Vector3 firstPoint = center + new Vector3(1, 0, 1) * DEFAULT_SIZE;
        area.meshPoints.Add(firstPoint);
        for (int i = 1; i < sides; i++)
        {
            Vector3 point = Quaternion.AngleAxis(angle * i, Vector3.up) * firstPoint;
            area.meshPoints.Add(point);
        }
    }

    

    private void EditMesh()
    {
        if (area.meshPoints == null || area.meshPoints.Count == 0)
        {
            area.meshPoints = new List<Vector3>();
        }

        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }
        
        Vector3 point = FindPoint();
        if (!CloseToPoints(point))
        {
            area.meshPoints.Add(point);
        }
    }

    private void DrawEditHandles()
    {
        if (area.meshPoints == null)
        {
            return;
        }
        int length = area.meshPoints.Count;
        for (int i = 0; i < length; i++)
        {
            Vector3 point = area.meshPoints[i];
            area.meshPoints[i] = Handles.PositionHandle(point, Quaternion.identity);

            if (i > 0)
            {
                // Join the previous one with the current one
                Vector3 previous = area.meshPoints[i - 1];
                Handles.DrawLine(previous, point);
            }
            if (i == (length - 1))
            {
                // Join the last one and the first one
                Vector3 first = area.meshPoints[0];
                Handles.DrawLine(point, first);
            }
        }
    }
    
    private void DrawHandles()
    {
        if (area.meshPoints == null)
        {
            return;
        }
        int length = area.meshPoints.Count;
        for (int i = 0; i < length; i++)
        {
            Vector3 point = area.meshPoints[i];
            Handles.SphereHandleCap(
                0,
                point,
                Quaternion.identity, 
                1,
                EventType.Repaint
            );

            if (i > 0)
            {
                // Join the previous one with the current one
                Vector3 previous = area.meshPoints[i - 1];
                Handles.DrawLine(previous, point);
            }
            if (i == (length - 1))
            {
                // Join the last one and the first one
                Vector3 first = area.meshPoints[0];
                Handles.DrawLine(point, first);
            }
        }
    }

    private bool Selected()
    {
        return areaMaker.gameObject.IsSelectedInEditor();
    }

    private bool CloseToPoints(Vector3 point)
    {
        foreach (Vector3 meshPoint in area.meshPoints)
        {
            if (Vector3.Distance(point, meshPoint) <= MINIMUM_CLICK_DISTANCE)
            {
                return true;
            }
        }
        return false;
    }

    private Vector3 FindPoint()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (templatePlane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance);
        }
        return areaMaker.transform.position;
    }

    private void OnEnable()
    {
        areaMaker = (AreaMaker) target;
        templatePlane = new Plane(areaMaker.transform.up, areaMaker.transform.position);
        mainCamera = Camera.main;
    }
}