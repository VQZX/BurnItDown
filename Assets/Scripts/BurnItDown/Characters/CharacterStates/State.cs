using System;
using Flusk.Utility;

namespace BurnItDown.Characters.CharacterStates
{
    /// <summary>
    /// The base state class for the player character
    /// </summary>
    [Serializable]
    public class State : IState
    {
        protected StateMachine<State> controllingStateMachine;
        protected Character controllingCharacter;

        public void SetStateMachine(StateMachine<State> stateMachine)
        {
            controllingStateMachine = stateMachine;
        }

        public void SetCharacter(Character character)
        {
            controllingCharacter = character;
        }
        
        public virtual void Enter(IState previousState)
        {
        }

        public virtual void Tick()
        {
        }

        public virtual void Exit(IState nextState)
        {
        }
    }
}