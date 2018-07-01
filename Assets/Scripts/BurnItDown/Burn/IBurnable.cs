using UnityEngine;

namespace BurnItDown.Burn
{
    /// <summary>
    /// The interface assigning to the components that can be set on fire
    /// </summary>
    public interface IBurnable
    {
        void SetAlight(Vector3 position);

        Vector3 BurnPoint();
    }
}