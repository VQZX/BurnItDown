using UnityEngine;

namespace MGSA.AreaMesh
{
    public class AreaMaker : MonoBehaviour
    {
        [SerializeField]
        public Area area;

        [SerializeField]
        protected MeshFilter filter;

        public void Save()
        {
            area.Save();
            filter.sharedMesh = area.SavedMesh;
        }
    
#if UNITY_EDITOR
        [SerializeField, HideInInspector]
        public bool isEditing;
#endif
    }
}