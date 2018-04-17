using UnityEngine;

namespace BurnItDown
{
    public class BurnItDownStateMachineBehaviour : StateMachineBehaviour
    {
        protected BurnItDownLevelManager LevelManager
        {
            get
            {
                return (BurnItDownLevelManager) BurnItDownLevelManager.Instance ; 
            }
        }

        public GameManager GameManager
        {
            get { return GameManager.Instance; }
        }
    }
}