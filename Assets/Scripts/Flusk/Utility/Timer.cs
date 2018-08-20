using System;
using UnityEngine;

namespace Flusk.Utility
{
    public class Timer
    {
        public Action Complete;

        protected float currentTime = 0;
        protected readonly float goalTime = 0;

        public Timer (float time, Action onComplete = null )
        {
            currentTime = 0;
            goalTime = time;
            Complete = onComplete;
        }

        public virtual void Tick (float deltaTime)
        {
            currentTime += deltaTime;
            if ( currentTime > goalTime )
            {
                Fire();
            }
        }

        private void Fire ()
        {
            if ( Complete != null )
            {
                Complete();
            }
        }
    }
}
