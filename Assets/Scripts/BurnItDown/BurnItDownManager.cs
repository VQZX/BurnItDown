using UnityEngine;

namespace BurnItDown
{
    public class BurnItDownManager : BurnItDownBehaviour
    {
        /// <summary>
        /// Configuration for if the manager should add itself
        /// </summary>
        [SerializeField]
        protected bool addSelf;
        
        /// <summary>
        /// Base functionality and add self to game manager
        /// </summary>
        protected override void Start()
        {
            if (addSelf)
            {
                base.Start();
                gameManager.AddManager(GetType(), this);  
            }
        }
    }
}