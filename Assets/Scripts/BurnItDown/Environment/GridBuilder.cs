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

        public virtual Vector2 InitialPosition
        {
            get
            {
                return new Vector2(transform.position.x, transform.position.y);
            }
        }

#if UNITY_EDITOR
        public
#else
        private
#endif
            void GenerateBlocks()
        {
            DestroyBlocks();
            generatedBlocks = new List<T>();
            Vector2IntUtil.Run(size, CreateBlock);
        }
        
#if UNITY_EDITOR
        public
#else
        private
#endif
            void DestroyBlocks()
        {
            if (transform.childCount == 0)
            {
                return;
            }
            if (generatedBlocks != null && generatedBlocks.Count > 0)
            {
                generatedBlocks.Run(DestroyBlockImmediate);
            }
            else
            {
                generatedBlocks = new List<T>(transform.childCount);
                GetComponentsInChildren(generatedBlocks);
                if (generatedBlocks.Count == 0)
                {
                    return;
                }
                DestroyBlocks();
            }

            generatedBlocks = null;
        }

        protected abstract void DestroyBlock(T item);
        protected abstract void DestroyBlockImmediate(T item);
        protected abstract void CreateBlock(int i, int j);
    }
}