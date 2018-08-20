using System;
using BurnItDown.Burn.Burners;
using Flusk.Utility;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BurnItDown.Burn.Spreading
{
    public class FireSpreadTimer : Timer
    {
        private IBurnable burnable;
        
        public FireSpreadTimer(IBurnable burnable, float time, Action onComplete = null) : base(time, onComplete)
        {
            this.burnable = burnable;
            Complete = RepeatFire;
            
        }

        public void RepeatFire()
        {
            IBurnable neighbour;
            IFire fire;
            burnable.FindNeighbour(out neighbour, out fire);
            if (neighbour == null || fire == null)
            {
                currentTime = 0;
                return;
            }
            Vector3 position = neighbour.BurnPoint();
            
            GameObject newFireObject = Object.Instantiate(fire.FireObject);
            newFireObject.name = fire.FireObject.name;
            IFire newFire = newFireObject.GetComponent<IFire>();
            
            neighbour.SetAlight(position, newFire);

                        
            currentTime = 0;
        }
    }
}