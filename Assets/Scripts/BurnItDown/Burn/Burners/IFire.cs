using UnityEngine;

namespace BurnItDown.Burn.Burners
{
    public interface IFire
    {
        void Extinguish();
        void Burn(Vector3 position);
        
        GameObject FireObject { get; }
    }
}