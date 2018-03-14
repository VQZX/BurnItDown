using System;
using BurnItDown.Character.CharacterStates;
using Flusk.Utility;
using UnityEngine;
using Motion = BurnItDown.Character.CharacterStates.Motion;

namespace BurnItDown.Character
{
    public class Character : BurnItDownBehaviour
    {
        [SerializeField]
        protected CharacterConfiguration configuration;
        public CharacterConfiguration Configuration {get { return configuration; }}

        public CharacterStateMachine StateMachine;
        private Falling falling;
        private Grounded grounded;
        private Cutscene cutscene;
        private Motion motion;
        
        /// <summary>
        /// Initalize the states and add them
        /// </summary>
        protected override void Start()
        {
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
    }
}