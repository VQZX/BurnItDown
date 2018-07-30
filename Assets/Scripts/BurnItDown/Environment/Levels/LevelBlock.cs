using System.Collections.Generic;
using BurnItDown.Burn;
using BurnItDown.Burn.Burners;
using Flusk.Extensions;
using UnityEngine;

namespace BurnItDown.Environment.Levels
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class LevelBlock : Block, IBurnable
    {
        private LevelGridData data;

        private new BoxCollider2D collider2D;

        public BurnContainer BurnContainer { get; private set; }

        /// <summary>
        /// The attached game object
        /// </summary>
        public GameObject BurningObject
        {
            get { return gameObject; }
        }
        
        public void Extinguish()
        {
            BurnContainer.Extinguish();
            BurnManager.Instance.UnregisterBurn(this);
        }

        public IBurnable FindNeighbour()
        {
            float radius = collider2D.size.magnitude;
            List<IBurnable> burnables = new List<IBurnable>();
            foreach (var fire in BurnContainer)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(fire.FireObject.transform.position, radius);
                foreach (var collider in colliders)
                {
                    var burnable = collider.GetComponent<IBurnable>();
                    if (burnable != null)
                    {
                        burnables.Add(burnable);
                    }
                }
            }

            int randomIndex = Random.Range(0, burnables.Count);
            return burnables[randomIndex];
        }

        public void FindNeighbour(out IBurnable burnable, out IFire fire)
        {
            float radius = collider2D.size.magnitude;
            List<BurnableFire> burnableFires = new List<BurnableFire>();
            foreach (var fireStarter in BurnContainer)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(fireStarter.FireObject.transform.position, radius);
                foreach (var collider in colliders)
                {
                    var burn = collider.GetComponent<IBurnable>();
                    if (burn != null)
                    {
                        burnableFires.Add(new BurnableFire(burn, fireStarter));
                    }
                }
            }

            int index = Random.Range(0, burnableFires.Count);
            burnable = burnableFires[index].Burnable;
            fire = burnableFires[index].Fire;
        }


        public void Initialise(LevelGridData data)
        {
            this.data = data;
            transform.parent = data.RootTransform;
            transform.localPosition = data.LocalPosition + (Vector3)data.Size.Multiply(0.5f);
        }

        public void ActivateSecret()
        {
            data.BlockSecret.ActivateSecret();
        }
 
        protected virtual void Awake()
        {
            collider2D = gameObject.AddComponent<BoxCollider2D>();
            BurnContainer = new BurnContainer();
        }

        public void SetAlight(Vector3 position, IFire fire)
        {
            fire.Burn(position);
            BurnContainer.Add(fire);
            Debug.LogFormat("Set Alight: {0}", this);
            RegisterBurn();
        }

        public Vector3 BurnPoint()
        {
            return GetBurnPosition();
        }

        public void RegisterBurn()
        {
            BurnManager.Instance.RegisterBurn(this);
        }

        public Vector3 GetBurnPosition()
        {
            return transform.position;
        }
    }
}