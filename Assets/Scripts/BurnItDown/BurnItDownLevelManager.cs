using UnityEngine;

namespace BurnItDown
{
    public class BurnItDownLevelManager : LevelManager
    {
        [SerializeField]
        protected Character.Character player;

        public Character.Character Player
        {
            get { return player; }
        }
    }
}