using Flusk.Utility;

namespace BurnItDown.Characters.CharacterStates
{
    public class CharacterStateMachine : KeyStateMachine<CharacterStates, State>
    {
        private readonly Character character;
        
        public CharacterStateMachine(Character character)
        {
            this.character = character;
        }
        
        public override void AddState(CharacterStates key, State state)
        {
            base.AddState(key, state);
            state.SetCharacter(character);
            state.SetStateMachine(this);
        }
    }
}