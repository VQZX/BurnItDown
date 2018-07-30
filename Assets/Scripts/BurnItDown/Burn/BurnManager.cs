using System.Collections.Generic;
using BurnItDown.Burn.Spreading;
using Flusk.Patterns;
using UnityEngine;

namespace BurnItDown.Burn
{
    public class BurnManager : Singleton<BurnManager>
    {
        [SerializeField]
        protected FireSpreader spreader;
        private List<IBurnable> burnables;

        public void RegisterBurn(IBurnable burnable)
        {
               spreader.Add(burnable);         
        }

        public void UnregisterBurn(IBurnable burnable)
        {
            spreader.Remove(burnable);
        }
    }
}