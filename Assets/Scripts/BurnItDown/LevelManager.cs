using System;
using System.Collections.Generic;
using Flusk.Patterns;
using UnityEngine;

namespace BurnItDown
{
    public class LevelManager : Singleton<LevelManager>
    {
        /// <summary>
        /// The list of managers 
        /// </summary>
        [SerializeField]
        protected List<BurnItDownManager> managers;

        [SerializeField]
        protected List<BurnItDownBehaviour> burnItDownBehaviours;

        /// <summary>
        /// The main game manager
        /// </summary>
        private GameManager gameManager;

        /// <summary>
        /// All the burn it level dependencies reference by type (obviously unique types)
        /// </summary>
        private Dictionary<Type, BurnItDownBehaviour> burnItDownBehaviourReference;

        /// <summary>
        /// Cache the reference to the manager
        /// </summary>
        protected virtual void Start()
        {
            if (!GameManager.TryGetInstance(out gameManager))
            {
                Debug.LogError("The Game Manager does not exist");
                return;
            }
            
            BurnItDownManager[] children = GetComponentsInChildren<BurnItDownManager>();
            managers = new List<BurnItDownManager>(children);
            foreach (var manager in managers)
            {
                gameManager.AddManager(manager.GetType(), manager);
            }
            burnItDownBehaviourReference = new Dictionary<Type, BurnItDownBehaviour>();
            foreach (BurnItDownBehaviour behaviour in burnItDownBehaviours)
            {
                behaviour.Init();
                burnItDownBehaviourReference.Add(behaviour.GetType(), behaviour);
            }
            
            
            gameManager.SetCurrentLevel(this);
        }
    }
}