using System;
using UnityEngine;

namespace MGSA.Grid
{
    [Serializable]
    public class GridData
    {
        public enum SoilType
        {
            Alkaline,
            Clay,
            Peat,
            Loam,
            Volcanic
        }

        [SerializeField]
        public SoilType soiltype;

        [SerializeField]
        public float Temperature;

        [SerializeField]
        public float depth;

        public void CycleSoil()
        {
            int index = (int)(++soiltype);
            index = index % 5;
            soiltype = (SoilType) index;
        }
    }
}