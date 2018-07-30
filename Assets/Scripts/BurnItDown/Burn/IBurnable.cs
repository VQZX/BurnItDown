using BurnItDown.Burn.Burners;
using UnityEngine;

namespace BurnItDown.Burn
{
    /// <summary>
    /// The interface assigning to the components that can be set on fire
    /// </summary>
    public interface IBurnable
    {
        void SetAlight(Vector3 position, IFire fire);

        Vector3 BurnPoint();

        void RegisterBurn();

        void Extinguish();
        
        BurnContainer BurnContainer { get; }
        
        GameObject BurningObject { get; }

        IBurnable FindNeighbour();
        
        void FindNeighbour(out IBurnable burnable, out IFire fire);
    }
}