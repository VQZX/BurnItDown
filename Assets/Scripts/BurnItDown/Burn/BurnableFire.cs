using BurnItDown.Burn.Burners;

namespace BurnItDown.Burn
{
    public struct BurnableFire
    {
        public IBurnable Burnable;
        public IFire Fire;

        public BurnableFire(IBurnable burnable, IFire fire)
        {
            Burnable = burnable;
            Fire = fire;
        }
    }
}