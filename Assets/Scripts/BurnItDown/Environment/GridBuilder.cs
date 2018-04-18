using System.Collections.Generic;
using Flusk.Utility;
using UnityEngine;

namespace BurnItDown.Environment
{
    public abstract class GridBuilder<T> : BurnItDownBehaviour where T : Block
    {
        [SerializeField]
        protected Vector2Int size;

        [SerializeField, HideInInspector]
        protected List<T> generatedBlocks;
        
#if UNITY_EDITOR
        public
#else
        private
#endif
            void GenerateBlocks()
        {
            if (generatedBlocks != null)
            {
                generatedBlocks.Run(DestroyBlock);
            }
            generatedBlocks = new List<T>();
            Vector2IntUtil.Run(size, CreateBlock);
        }

        protected abstract void DestroyBlock(T item);
        protected abstract void CreateBlock(int i, int j);
    }
}