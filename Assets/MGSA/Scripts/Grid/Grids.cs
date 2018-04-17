using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MGSA.Grid
{
    [Serializable]
    public class Grids : IList<GridBlock>
    {
        [SerializeField]
        private List<GridBlock> listImplementation;

        public Grids(int length)
        {
            listImplementation = new List<GridBlock>(length);
        }

        public GridBlock FindClosest(Vector3 point)
        {
            float closestDistance = float.MaxValue;
            GridBlock selected = null;
            foreach (GridBlock gridblock in listImplementation)
            {
                float distance = Vector3.Distance(point, gridblock.RealWorldPoint);       
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    selected = gridblock;
                    Debug.Log("Grid: "+gridblock.GetPrettyCoords()+" Distance: "+closestDistance+" "+gridblock.RealWorldPoint);
                }
            }
            return selected;
        }
    
        public IEnumerator<GridBlock> GetEnumerator()
        {
            return listImplementation.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) listImplementation).GetEnumerator();
        }

        public void Add(GridBlock item)
        {
            listImplementation.Add(item);
        }

        public void Clear()
        {
            listImplementation.Clear();
        }

        public bool Contains(GridBlock item)
        {
            return listImplementation.Contains(item);
        }

        public void CopyTo(GridBlock[] array, int arrayIndex)
        {
            listImplementation.CopyTo(array, arrayIndex);
        }

        public bool Remove(GridBlock item)
        {
            return listImplementation.Remove(item);
        }

        public int Count
        {
            get { return listImplementation.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public int IndexOf(GridBlock item)
        {
            return listImplementation.IndexOf(item);
        }

        public void Insert(int index, GridBlock item)
        {
            listImplementation.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            listImplementation.RemoveAt(index);
        }

        public GridBlock this[int index]
        {
            get { return listImplementation[index]; }
            set { listImplementation[index] = value; }
        }
    }
}