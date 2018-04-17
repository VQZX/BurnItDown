using System;
using UnityEngine;

namespace BurnItDown.Character.AnimationBehaviour
{
	public class AvatarEntrance : BurnItDownStateMachineBehaviour 
	{
		readonly Vector3 offset = new Vector3(-1.51f, 0.35f, 0);
		
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			LevelManager.Player.AvatarDisplay.AdjustLocalPosition(offset);
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
		{
			LevelManager.Player.AvatarDisplay.ResetLocalPosition();
		}
	}
}
