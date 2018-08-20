using System;
using UnityEngine;

namespace Flusk.Structures
{
    [Serializable]
    public struct Range : ISerializationCallbackReceiver
    {
        public float Min;
        public float Max;

        public float Median
        {
            get { return ((Min + Max) * 0.5f); }
            private set { throw new NotImplementedException(); }
        }

        public Range(float min, float max)
        {
            Min = min;
            Max = max;
            Validate();
        }

        public void Validate()
        {
            var min = Min;
            var max = Max;
            Min = Mathf.Min(min, max);
            Max = Mathf.Max(min, max);
        }

        public float Length
        {
            get { return (Max - Min); }
        }

        public bool WithinRange(float x)
        {
            return (x <= Max && x >= Min);
        }

        public float Random()
        {
            return UnityEngine.Random.Range(Min, Max);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Min, Max);
        }

        public void OnBeforeSerialize()
        {
            Validate();
        }

        public void OnAfterDeserialize()
        {
            Validate();
        }
    }
}