using UnityEngine;

namespace BurnItDown
{
    /// <summary>
    /// Provides access to data concerning the ground
    /// </summary>
    public class GroundReference : BurnItDownBehaviour
    {
        /// <summary>
        /// The transform that dictates the data concerning the global ground plan
        /// </summary>
        [SerializeField]
        protected Transform planeReference;
        
        /// <summary>
        /// The plane that holds all the data concerning the ground
        /// </summary>
        public Plane Plane { get; private set; }

        public override void Init()
        {
            base.Start();
            if (planeReference != null)
            {
                Plane = new Plane(planeReference.transform.position, planeReference.transform.up);
            }
        }
        
    }
}