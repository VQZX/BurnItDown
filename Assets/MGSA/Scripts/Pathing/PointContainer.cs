using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MGSA.Pathing
{
    public class PointContainer : MonoBehaviour
    {
        public Vector3 Position
        {
            get { return point.point; }
            set
            {
                transform.position = value;
                point.point = value;
            }
        }

        public bool IsLeaf
        {
            get { return point.children.Count == 0; }
        }
    
        public PathPoint point;

#if UNITY_EDITOR
        public void ForceCheck()
        {
            PointContainer[] container = GetComponentsInChildren<PointContainer>();
            point.children = new List<PointContainer>();
            foreach (PointContainer current in container)
            {
                if (current == this || current.transform.parent != transform)
                {
                    continue;
                }
                point.children.Add(current);
            }

            point.point = transform.position;
            point.Validate();
        }
    
        private void OnValidate()
        {
            ForceCheck();
        }


        [MenuItem("GameObject/Point Container", false, 11)]
        public static void Create()
        {
            if (Selection.gameObjects.Length > 1)
            {
                return;
            }
            GameObject parent = Selection.activeGameObject;
            GameObject clone = new GameObject();
            clone.name = "Point Container";
            clone.AddComponent<PointContainer>();
            if (parent != null)
            {
                clone.transform.SetParent(parent.transform);
            }
        }
#endif
    
    }
}