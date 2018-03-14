using UnityEngine;

namespace BurnItDown
{
    public class BurnItDownComponent : MonoBehaviour
    {
        private BurnItDownBehaviour behaviour;

        protected virtual void Awake()
        {
            behaviour = GetComponent<BurnItDownBehaviour>();
        }
    }
}