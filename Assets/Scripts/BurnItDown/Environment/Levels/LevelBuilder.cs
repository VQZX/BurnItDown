using System.Collections.Generic;
using Flusk.Utility;
using UnityEngine;

namespace BurnItDown.Environment.Levels
{
    [RequireComponent(typeof(LevelBuilderGridCapture))]
    public class LevelBuilder : GridBuilder<LevelBlock>
    {
        [SerializeField]
        protected LevelBlock outsideBlock;

        [SerializeField]
        protected LevelBlock roofblock;
 
        [SerializeField]
        protected Vector2Int gridSize;
        
        
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
            Vector2IntUtil.Run(gridSize, CreateBlock);    
        }

        protected override void CreateBlock(int i, int j)
        {
            
        }
    }
}