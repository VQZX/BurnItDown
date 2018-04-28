using UnityEngine;

namespace BurnItDown.Environment.EnvironmentProperty
{
    [CreateAssetMenu(fileName = "BlockFunction.asset", menuName = "Block Property", order = 0)]
    public abstract class BlockFunctionProperty : ScriptableObject
    {
        public abstract void ActivateSecret();
    }
}