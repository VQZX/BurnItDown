using Flusk.Utility;

namespace BurnItDown.Character.CharacterStates
{
    public class CharacterStateMachine : StateMachine<State>
    {
        private readonly Character character;
        
        public CharacterStateMachine(Character character)
        {
            this.character = character;
        }
        
        public virtual void Add(State state)
        {
            base.AddState(state);
            state.SetCharacter(character);
            state.SetStateMachine(this);
        }
    }
}