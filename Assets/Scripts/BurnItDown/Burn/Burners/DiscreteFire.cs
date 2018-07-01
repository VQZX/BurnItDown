using UnityEngine;

namespace BurnItDown.Burn.Burners
{
    public class DiscreteFire : BurnItDownBehaviour
    {
        [SerializeField]
        protected ParticleSystem fire;

        [SerializeField]
        protected ParticleSystem extinguishTemplate;
        
        public void Extinguish ()
        {
            if (extinguishTemplate == null)
            {
                return;
            }

            Instantiate(extinguishTemplate, transform.position, transform.rotation);
        }
    }
}