using System;
using BurnItDown.Character.CharacterStates;
using BurnItDown.Character.Components;
using Flusk.Animation;
using UnityEngine;
using Motion = BurnItDown.Character.CharacterStates.Motion;

namespace BurnItDown.Character
{
    public class Character : BurnItDownBehaviour
    {
        [SerializeField]
        protected CharacterConfiguration configuration;

        public CharacterConfiguration Configuration
        {
            get { return configuration; }
        }

        [SerializeField]
        protected float speed;

        [SerializeField]
        protected Transform avatar;

        public CharacterStateMachine StateMachine;
        private Falling falling;
        private Grounded grounded;
        private Cutscene cutscene;
        private Motion motion;

        public AvatarDisplay AvatarDisplay { get; private set; }
        public Physics2DLocomotion Locomotion { get; private set; }

        protected void Awake()
        {
            AvatarDisplay = GetComponentInChildren<AvatarDisplay>();
            Locomotion = GetComponentInChildren<Physics2DLocomotion>();
        }

        /// <summary>
        /// Initalize the states and add them
        /// </summary>
        protected override void Start()
        {
            base.Start();

            StateMachine = new CharacterStateMachine(this);

            falling = new Falling();
            grounded = new Grounded();
            motion = new Motion();
            cutscene = new Cutscene();


            // Add states
            StateMachine.AddState(falling);
            StateMachine.AddState(grounded);
            StateMachine.AddState(motion);
            StateMachine.AddState(cutscene);
        }

        protected void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.D))
            {
                Locomotion.Push(Vector2.right * speed);
            }

            if (Input.GetKey(KeyCode.A))
            {
                Locomotion.Push(Vector2.left * speed);
            }

            AvatarDisplay.Animator.Speed = Locomotion.Speed;
        }
    }
}