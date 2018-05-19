using System;
using BurnItDown.Character.Components;
using UnityEngine;

namespace BurnItDown.Character
{
    [Serializable]
    public class CharacterConfiguration
    {
        [SerializeField]
        protected Foot footPosition;
        public Foot FootPosition {get { return footPosition; }}

        [SerializeField]
        protected Head headPosition;
        public Head HeadPosition {get { return headPosition; }}

        [SerializeField]
        protected Rigidbody2D mainRigidbody;
        public Rigidbody2D MainRigidbody { get { return mainRigidbody; } }
    }
}