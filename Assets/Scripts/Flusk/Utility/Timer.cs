using System;

namespace Flusk.Utility
{
    public class Timer
    {
        public Action Complete;

        protected float time = 0;
        protected float goal = 0;

        public Timer (float time, Action onComplete = null )
        {
            this.time = time;
            Complete = onComplete;
        }

        public virtual void Tick (float deltaTime)
        {
            time += deltaTime;
            if ( time > goal )
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
