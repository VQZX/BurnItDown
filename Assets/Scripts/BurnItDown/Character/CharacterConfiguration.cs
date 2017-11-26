using System;
using UnityEngine;

namespace BurnItDown.Character
{
    [Serializable]
    public class CharacterConfiguration
    {
        [SerializeField]
        protected Transform footPosition;
        public Transform FootPosition {get { return footPosition; }}

        [SerializeField]
        protected Transform headPosition;
        public Transform HeadPosition {get { return headPosition; }}

        [SerializeField]
        protected Rigidbody mainRigidbody;
        public Rigidbody MainRigidbody { get { return mainRigidbody; } }
    }
}