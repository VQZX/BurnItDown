using System.Collections.Generic;
using Flusk.Structures;
using UnityEngine;

namespace BurnItDown.Burn.Spreading
{
    public class FireSpreader : BurnItDownBehaviour
    {
        public struct BurnableTimers
        {
            public IBurnable Burnable;
            public FireSpreadTimer Timer;

            public BurnableTimers(IBurnable burnable, FireSpreadTimer timer)
            {
                Burnable = burnable;
                Timer = timer;
            }
        }
        
        [SerializeField]
        protected Range range;

        private List<BurnableTimers> burnableTimers = new List<BurnableTimers>();

        /// <summary>
        /// This ignores repeats, fix it. It will cause problems very quickly
        /// </summary>
        /// <param name="burnable"></param>
        public void Add(IBurnable burnable)
        {

            var random = range.Random();
Debug.Log("Random: "+range+" "+random);
            var timer = new FireSpreadTimer(burnable, random);
            burnableTimers.Add(new BurnableTimers(burnable, timer));
        }

        /// <summary>
        /// This ignores repeats, fix it. It will cause problems very quickly
        /// </summary>
        /// <param name="burnable"></param>
        public void Remove(IBurnable burnable)
        {
            int index = -1;
            int count = burnableTimers.Count;
            for (int i = 0; i < count; i++)
            {
                var current = burnableTimers[i];
                if (current.Burnable == burnable)
                {
                    index = i;
                    break;
                }
            }
            
            burnableTimers.RemoveAt(index);
        }

        protected virtual void Update()
        {
            foreach (var spreadTimer in burnableTimers)
            {
                spreadTimer.Timer.Tick(Time.deltaTime);
            }
        }
    }
}