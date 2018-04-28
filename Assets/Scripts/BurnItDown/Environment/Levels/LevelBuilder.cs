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

        protected override void CreateBlock(int i, int j)
        {
            
        }
    }
}