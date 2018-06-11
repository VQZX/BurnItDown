using BurnItDown.Character.CharacterStates;
using BurnItDown.Character.Components;
using UnityEngine;
using Motion = BurnItDown.Character.CharacterStates.Motion;
using StateName = BurnItDown.Character.CharacterStates.CharacterStates;

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
            StateMachine.AddState(StateName.Falling, falling);
            StateMachine.AddState(StateName.Grounded, grounded);
            StateMachine.AddState(StateName.Motion, motion);
            StateMachine.AddState(StateName.Cutscene, cutscene);
        }

        protected void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.D))
            {
                Locomotion.Push(Vector2.right * speed);
                AvatarDisplay.FaceRight();
            }

            if (Input.GetKey(KeyCode.A))
            {
                Locomotion.Push(Vector2.left * speed);
                AvatarDisplay.FaceLeft();
            }

            AvatarDisplay.Animator.Speed = Locomotion.Speed;
        }
    }
}