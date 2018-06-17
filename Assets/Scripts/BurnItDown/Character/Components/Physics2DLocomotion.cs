using System;
using UnityEngine;

namespace BurnItDown.Character.Components
{
    public class Physics2DLocomotion : BurnItDownBehaviour
    {
        [SerializeField]
        protected float maxSpeed;

        [SerializeField]
        protected float speed;

        public float Speed
        {
            get { return rigidbody2D.velocity.magnitude; }
        }
        
        private new Rigidbody2D rigidbody2D;

        public void SetSpeed(Vector3 velocity)
        {
            if (Mathf.Abs(velocity.magnitude) >= maxSpeed)
            {
                return;
            }

            rigidbody2D.velocity = velocity;
        }
        
        public void Push(Vector3 push)
        {
            rigidbody2D.AddForce(push);
            if (Math.Abs(maxSpeed) < float.Epsilon)
            {
                return;
            }

            if (rigidbody2D.velocity.magnitude > maxSpeed)
            {
                rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxSpeed;
            }
        }

        protected virtual void Awake()
        {
            rigidbody2D = GetComponentInChildren<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            speed = Speed;
        }
    }
}