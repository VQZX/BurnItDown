using Flusk.Extensions;
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
            transform.localPosition = data.LocalPosition + (Vector3)data.Size.Multiply(0.5f);
        }

        public void ActivateSecret()
        {
            data.BlockSecret.ActivateSecret();
        }
    }
}