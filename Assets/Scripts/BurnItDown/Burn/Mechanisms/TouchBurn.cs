using System.Collections.Generic;
using BurnItDown.Burn.Burners;
using Flusk.Utility;
using UnityEngine;

namespace BurnItDown.Burn.Mechanisms
{
    /// <summary>
    /// The controller for when the character is on fire, and setting
    /// every valid item alight
    /// </summary>
    public class TouchBurn : BurnMechanism
    {
        [SerializeField]
        protected Transform touchBurnPoint;

        [SerializeField]
        protected float radius;

        [SerializeField]
        protected float timeBetweenBurns = 0.5f;

        [SerializeField]
        protected DiscreteFire fireTemplate;

        private Timer timer;
       
        public override void Burn()
        {
            timer = new Timer(timeBetweenBurns, Burn);
            SelectBurnPoint();

        }

        private void SelectBurnPoint()
        {
            Collider2D[] collection = Physics2D.OverlapCircleAll(touchBurnPoint.position, radius);
            List<IBurnable> list = new List<IBurnable>();
Debug.Log(list.Count);
            foreach (var collider in collection)
            {
                var burnable = collider.GetComponent<IBurnable>();
                if (burnable != null)
                {
                    list.Add(burnable);
                }
            }

            if (list.Count == 0)
            {
                return;
            }
            int index = Random.Range(0, list.Count);
            var fire = Instantiate(fireTemplate, list[index].BurnPoint() - Vector3.forward, transform.rotation);
            list[index].SetAlight(list[index].BurnPoint(), fire);
        }

        private void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                    timer = new Timer(timeBetweenBurns, Burn);
            }
            else if ( Input.GetMouseButtonUp(0))
            {
                timer = null;
            }

            if (timer != null)
            {
                timer.Tick(Time.fixedDeltaTime);
            }
        }
        
        
        #if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(touchBurnPoint.position, radius);
        }
#endif
    }
}