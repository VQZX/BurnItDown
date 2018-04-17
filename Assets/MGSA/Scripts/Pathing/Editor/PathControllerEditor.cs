using MGSA.Pathing;
using Pathing.Editor;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PathController))]
public class PathControllerEditor : Editor
{
    private PathController pathController;

    private PathAnimators pathAnimators;

    private void OnSceneGUI()
    {
        DrawPath();
        pathAnimators.Update();
        Repaint();
    }

    private void DrawPath()
    {
        if (pathController.gameObject.IsSelectedInEditor())
        {
            Draw(pathController.path.FirstContainer);    
        }
    }

    private void Draw(PointContainer pointContainer)
    {
        pointContainer.Position = DrawPositionHandle(pointContainer.Position);
        Handles.Label(pointContainer.Position, pointContainer.gameObject.name);
        if (!pointContainer.IsLeaf)
        {
            foreach (var child in pointContainer.point.children)
            {
                Handles.DrawLine(pointContainer.point.point, child.point.point);
                Draw(child);
            }
        }
        else if ( pathController.wrapPath )
        {
            Handles.DrawLine(pointContainer.point.point, pathController.path.First.point);
        }
    }

    private Vector3 DrawPositionHandle(Vector3 position)
    {
        return Handles.PositionHandle(position, Quaternion.identity);
    }
    
    private void OnEnable()
    {
        pathController = (PathController) target;
        pathAnimators = new PathAnimators(path: pathController, 
            speed: 1f, size: 1f, wrap: pathController.wrapPath);
    }
}