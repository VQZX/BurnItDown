using System.Collections.Generic;
using UnityEngine;

namespace BurnItDown.Environment.Grids
{
    [RequireComponent(typeof(Grid))]
    public abstract class BurnItDownGrid<T> : BurnItDownBehaviour where T : IGridData
    {
        [SerializeField]
#if UNITY_EDITOR
        public 
#else
        protected 
#endif
        List<T> gridData;

        public IGridData FindClosest(Vector3 position)
        {
            float closestDistance = float.MaxValue;
            IGridData selected = null;

            foreach (T block in gridData)
            {
                float distance = Vector3.Distance(position, block.WorldPoint3());
                if (distance < closestDistance)
                {
                    selected = block;
                    closestDistance = distance;
                }
            }
            return selected;
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (gridData == null || gridData.Count == 0)
            {
                return;
            }
        
            foreach (T block in gridData)
            {
                block.DrawBlock();
            }
        }
#endif
    }
}