using System;
using BurnItDown.Burn.Mechanisms;
using BurnItDown.Characters;
using UnityEngine;

namespace BurnItDown.Burn
{
    public class BurnerCharacter : Character
    {
        private IBurnMechanism tool;

        protected override void Awake()
        {
            base.Awake();
            tool = GetComponentInChildren<IBurnMechanism>();
        }
    }
}