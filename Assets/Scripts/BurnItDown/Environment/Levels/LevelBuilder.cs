using UnityEngine;

namespace BurnItDown.Environment.Levels
{
    public class LevelBuilder : GridBuilder<LevelBlock>
    {
        [SerializeField]
        protected LevelBlock outsideBlock;

        [SerializeField]
        protected LevelBlock roofblock;
        
        
        protected override void DestroyBlock(LevelBlock item)
        {
            item.Destroy();
        }

        protected override void CreateBlock(int i, int j)
        {
            throw new System.NotImplementedException();
        }
    }
}