using BurnItDown.Characters.CharacterStates;
using BurnItDown.Characters.Components;
using UnityEngine;
using Motion = BurnItDown.Characters.CharacterStates.Motion;
using StateName = BurnItDown.Characters.CharacterStates.CharacterStates;

namespace BurnItDown.Characters
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

        protected virtual void Awake()
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

        /// <summary>
        /// Generalise this
        /// </summary>
        protected virtual void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.D))
            {
                Locomotion.SetSpeed(Vector2.right * speed);
                AvatarDisplay.FaceRight();
            }

            if (Input.GetKey(KeyCode.A))
            {
                Locomotion.SetSpeed(Vector2.left * speed);
                AvatarDisplay.FaceLeft();
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                Locomotion.SetSpeed(Vector3.zero);
            }

            AvatarDisplay.Animator.Speed = Locomotion.Speed;
        }
    }
}