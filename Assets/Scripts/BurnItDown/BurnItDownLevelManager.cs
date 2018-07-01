using BurnItDown.Characters;
using UnityEngine;

namespace BurnItDown
{
    public class BurnItDownLevelManager : LevelManager
    {
        [SerializeField]
        protected Character player;

        public Character Player
        {
            get { return player; }
        }
    }
}