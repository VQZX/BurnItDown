using UnityEngine;

namespace BurnItDown.Environment.Levels
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class LevelBlock : Block
    {
        private LevelGridData data;
        
        public void Initialise(LevelGridData data)
        {
            this.data = data;
            transform.parent = data.RootTransform;
        }

        public void ActivateSecret()
        {
            data.BlockSecret.ActivateSecret();
        }
    }
}