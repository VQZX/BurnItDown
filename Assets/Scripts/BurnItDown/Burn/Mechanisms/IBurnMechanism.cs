namespace BurnItDown.Burn.Mechanisms
{
    public interface IBurnMechanism
    {     
        /// <summary>
        /// Activate burn procedure
        /// </summary>
        void Burn();
        
        /// <summary>
        /// Allows burn procedure
        /// </summary>
        void SwitchOn();

        /// <summary>
        /// Prevents burn procedure
        /// </summary>
        void SwitchOff();
    }
}