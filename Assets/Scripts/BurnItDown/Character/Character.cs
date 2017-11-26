using System;
using BurnItDown.Character.CharacterStates;
using Flusk.Utility;
using UnityEngine;

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
        
        /// <summary>
        /// Initalize the states and add them
        /// </summary>
        protected override void Start()
        {
           StateMachine = new CharacterStateMachine(this);
            
            falling = new Falling();
            grounded = new Grounded();
            
            
            // Add states
            StateMachine.AddState(falling);
            StateMachine.AddState(grounded);
            
        }
    }
}