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

        public Vector2Int GridSize
        {
            get { return gridSize; }
        }

        private LevelBuilderGridCapture capture;

        protected void Awake()
        {
            capture = GetComponent<LevelBuilderGridCapture>();
        }
        
        
        protected override void DestroyBlock(LevelBlock item)
        {
            if (item == null)
            {
                return;
            }
            item.Destroy();
        }

        protected override void DestroyBlockImmediate(LevelBlock item)
        {
            if (item == null)
            {
                return;
            }
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
                    block = Create(woodBlock, transform);
                    break;
                case LevelGridData.Type.Brick:
                    block = Create(brickBlock, transform);
                    break;
            }

            if (block != null)
            {
                block.Initialise(data);
            }
            generatedBlocks.Add(block);
        }

        private int GetIndex(int i, int j)
        {
            return i + j + i * (gridSize.x);
        }
    }
}