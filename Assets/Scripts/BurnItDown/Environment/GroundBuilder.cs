﻿using System.Collections.Generic;
using Flusk.Utility;
using UnityEngine;

namespace BurnItDown.Environment
{
    public class GroundBuilder : BurnItDownBehaviour
    {
        [SerializeField]
        protected GroundBlock topGroundBlockTemplate;
        
        [SerializeField]
        protected GroundBlock bodyGroundBlockTemplate;

        [SerializeField]
        protected Vector2Int size;

        [SerializeField, HideInInspector]
        protected List<GroundBlock> generatedBlocks;
        
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
            generatedBlocks = new List<GroundBlock>();
            Vector2IntUtil.Run(size, CreateBlock);
        }

        private void CreateBlock(int i, int j)
        {
            var selection = (j == 0) ? topGroundBlockTemplate : bodyGroundBlockTemplate;
            var clone = Instantiate(selection, transform);
            clone.transform.localPosition = new Vector3(i, -j - 1) + (Vector3)Vector2.one * 0.5f;
        }

        private void DrawRect(int i, int j)
        {
            Rect rect = new Rect();
            rect.center = new Vector2(i, -j - 1) + (Vector2)transform.position;
            rect.width = 1;
            rect.height = 1;
            rect.DrawRect();
        }

        private void DestroyBlock(GroundBlock block)
        {
            block.Destroy();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Vector3 position = transform.position;
            const float length = 30;
            Gizmos.DrawLine(position + Vector3.left * length, position + Vector3.right * length);
            Gizmos.DrawLine(position + Vector3.down * length, position + Vector3.up * length);
            Vector2IntUtil.Run(size, DrawRect);
        }
#endif
    }
}