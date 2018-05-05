using System.Collections.Generic;
using Flusk.Utility;
using UnityEditor;
using UnityEngine;

namespace BurnItDown.Environment
{
    public abstract class GridBuilder<T> : BurnItDownBehaviour where T : Block
    {
        [SerializeField]
        protected Vector2Int blockSize;

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
        public virtual 
#else
        protected virtual 
#endif
            void GenerateBlocks()
        {
            DestroyBlocks();
            generatedBlocks = new List<T>();
            Vector2IntUtil.Run(blockSize, CreateBlock);
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

        protected R Create<R>(R block, Transform parent) where R : Block
        {
#if UNITY_EDITOR
            var instance = (R) PrefabUtility.InstantiatePrefab(block);
            instance.transform.SetParent(parent);
            return instance;
#else
            return Instantiate(block, parent);
#endif
        }

        protected R Create<R>(R block, Vector3 position, Quaternion rotation, Vector3 scale) where R : Block
        {
#if UNITY_EDITOR
            var instance = (R) PrefabUtility.InstantiatePrefab(block);
            instance.transform.SetPositionAndRotation(position, rotation);
            instance.transform.localScale = scale;
            return instance;
#else
            return Instantiate(block, position, rotation, scale);
#endif
        }

        protected abstract void DestroyBlock(T item);
        protected abstract void DestroyBlockImmediate(T item);
        protected abstract void CreateBlock(int i, int j);
    }
}