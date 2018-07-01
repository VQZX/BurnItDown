using UnityEngine;

namespace BurnItDown.Burn.Mechanisms
{
    /// <summary>
    /// The base class for all the way the character can set items on fire
    /// </summary>
    public abstract class BurnMechanism : BurnItDownBehaviour, IBurnMechanism
    {
        [SerializeField]
        protected KeyCode activateKeyCode;

        public abstract void Burn();
        
        public void SwitchOn()
        {
            enabled = true;
        }

        public void SwitchOff()
        {
            enabled = false;
        }
    }
}