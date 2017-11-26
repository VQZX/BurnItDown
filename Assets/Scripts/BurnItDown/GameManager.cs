using System;
using System.Collections.Generic;
using Flusk.Patterns;
using UnityEngine;

namespace BurnItDown
{
    public class GameManager : PersistentSingleton<GameManager>
    {
        /// <summary>
        /// The current level the player is navigating
        /// </summary>
        public LevelManager CurrentLevel { get; private set; }
        
        /// <summary>
        /// A collection of all the custom manager in the scene, one type per scene 
        /// (LevelManager, AIMAnager, PlayerManager)
        /// </summary>
        private Dictionary<Type, BurnItDownManager> managers = new Dictionary<Type, BurnItDownManager>();

        /// <summary>
        /// Adds managers to <see cref="managers"/> if there is not a same type added
        /// If there is more than one type, add a supermanager that controls both sub-managers
        /// </summary>
        /// <param name="type">
        /// The explicit manager type
        /// </param>
        /// <param name="manager">
        /// The instance of the manager
        /// </param>
        public void AddManager(Type type, BurnItDownManager manager)
        {            
            if (!managers.ContainsKey(type))
            {
                managers.Add(type, manager);
            }
            else
            {
                 Debug.LogErrorFormat("A manager of type {0} already exists. " +
                                      "If there is more than one manager of the same type, " +
                                      "consider creating a super manager " +
                                      "to control both.", type);   
            }
        }

        //TODO: the Game Manager should handle this on some sort of scene/level loaded
        /// <summary>
        /// Sets the current level
        /// </summary>
        public void SetCurrentLevel(LevelManager level)
        {
            CurrentLevel = level;
            
            // notify that the level is ready
        }
    }
}