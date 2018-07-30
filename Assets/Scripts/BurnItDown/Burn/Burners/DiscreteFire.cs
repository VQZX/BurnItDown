using UnityEngine;

namespace BurnItDown.Burn.Burners
{
    public class DiscreteFire : BurnItDownBehaviour, IFire
    {
        [SerializeField]
        protected ParticleSystem fire;

        [SerializeField]
        protected ParticleSystem extinguishTemplate;

        public GameObject FireObject
        {
            get { return gameObject; }
        }

        public void Burn( Vector3 postion)
        {
            transform.position = postion - Vector3.forward * 2;
            fire.Play();
        }
        
        public void Extinguish ()
        {
            if (extinguishTemplate == null)
            {
                return;
            }

            var smoke = Instantiate(extinguishTemplate, transform.position, transform.rotation);
            smoke.Play();
            // These should be pooled and ECS at some point
            Destroy();
        }
    }
}