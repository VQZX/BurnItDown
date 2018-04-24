using UnityEngine;

namespace BurnItDown
{
    public class BurnItDownBehaviour : MonoBehaviour
    {
        protected GameManager gameManager;

        public virtual void Destroy()
        {
            Destroy(gameObject);
        }
        
#if UNITY_EDITOR
        public virtual void DestroyImmediate()
        {
            DestroyImmediate(gameObject);
        }
#endif

        
        /// <summary>
        /// Called by the a manager, this is where any external object or data can be cached 
        /// </summary>
        public virtual void Init()
        {
        }
          
        /// <summary>
        /// Cache the reference to the Game Manager
        /// </summary>
        protected virtual void Start()
        {
            if (!GameManager.TryGetInstance(out gameManager))
            {
                Debug.LogError("GameManager not assigned.");
            }
        }

        
        protected static void Destroy(BurnItDownBehaviour behaviour)
        {
            behaviour.Destroy();
        }
    }
}