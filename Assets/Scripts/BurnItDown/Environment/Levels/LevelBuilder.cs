using System;
using System.Collections.Generic;
using Flusk.Utility;
using UnityEngine;

namespace BurnItDown.Environment.Levels
{
    [RequireComponent(typeof(LevelBuilderGridCapture))]
    public class LevelBuilder : GridBuilder<LevelBlock>
    {
        [SerializeField]
        protected LevelBlock brickBlock;

        [SerializeField]
        protected LevelBlock woodBlock;
 
        [SerializeField]
        protected Vector2Int gridSize;

        private LevelBuilderGridCapture capture;

        protected void Awake()
        {
            capture = GetComponent<LevelBuilderGridCapture>();
        }
        
        
        protected override void DestroyBlock(LevelBlock item)
        {
            item.Destroy();
        }

        protected override void DestroyBlockImmediate(LevelBlock item)
        {
            item.DestroyImmediate();
        }

#if UNITY_EDITOR
        public        
#else
        protected 
#endif
        override void GenerateBlocks()
        {
            DestroyBlocks();
            generatedBlocks = new List<LevelBlock>();
            capture = capture ?? GetComponent<LevelBuilderGridCapture>();
            Vector2IntUtil.Run(gridSize, CreateBlock);    
        }

        protected override void CreateBlock(int i, int j)
        {
            var data = capture.GetGridData(i, j);
            LevelBlock block = default(LevelBlock);
            switch (data.BlockType)
            {
                case LevelGridData.Type.Nothing:
                    block = null;
                    break;
                case LevelGridData.Type.Wood:
                    block = Instantiate(woodBlock, transform);
                    break;
                case LevelGridData.Type.Brick:
                    block = Instantiate(brickBlock, transform);
                    break;
            }
            generatedBlocks.Add(block);
        }

        private int GetIndex(int i, int j)
        {
            return i + j * generatedBlocks.Count;
        }
    }
}