using BurnItDown.Burn;
using Flusk.Extensions;
using UnityEngine;

namespace BurnItDown.Environment.Levels
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class LevelBlock : Block, IBurnable
    {
        private LevelGridData data;

        private new BoxCollider2D collider2D;
        
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
 
        protected virtual void Awake()
        {
            collider2D = gameObject.AddComponent<BoxCollider2D>();
        }

        public void SetAlight(Vector3 position)
        {
            // we dont really need this
        }

        public Vector3 BurnPoint()
        {
            return GetBurnPosition();
        }

        public Vector3 GetBurnPosition()
        {
            return transform.position;
        }
    }
}