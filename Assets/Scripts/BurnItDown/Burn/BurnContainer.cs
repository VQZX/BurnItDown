using System.Collections;
using System.Collections.Generic;
using BurnItDown.Burn.Burners;

namespace BurnItDown.Burn
{
    public class BurnContainer : IList<IFire>
    {
        public int MAX_AMOUNT = 3;

        public bool HasFire
        {
            get { return (fires != null && fires.Count > 0); }
        }
        
        private List<IFire> fires = new List<IFire>();

        public void Extinguish()
        {
            foreach (var fire in fires)
            {
                fire.Extinguish();
            }
            fires.Clear();
            fires = null;
        }
        
        public IEnumerator<IFire> GetEnumerator()
        {
            return fires.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) fires).GetEnumerator();
        }

        public void Add(IFire item)
        {
            if (fires.Count >= MAX_AMOUNT)
            {
                return;
            }
            
            fires.Add(item);
        }

        public void Clear()
        {
            fires.Clear();
        }

        public bool Contains(IFire item)
        {
            return fires.Contains(item);
        }

        public void CopyTo(IFire[] array, int arrayIndex)
        {
            fires.CopyTo(array, arrayIndex);
        }

        public bool Remove(IFire item)
        {
            return fires.Remove(item);
        }

        public int Count
        {
            get { return fires.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<IFire>) fires).IsReadOnly; }
        }

        public int IndexOf(IFire item)
        {
            return fires.IndexOf(item);
        }

        public void Insert(int index, IFire item)
        {
            fires.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            fires.RemoveAt(index);
        }

        public IFire this[int index]
        {
            get { return fires[index]; }
            set { fires[index] = value; }
        }
    }
}