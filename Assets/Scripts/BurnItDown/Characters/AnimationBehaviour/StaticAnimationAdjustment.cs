using UnityEngine;

namespace BurnItDown.Characters.AnimationBehaviour
{
	public class StaticAnimationAdjustment : BurnItDownStateMachineBehaviour
	{
		[SerializeField]
		protected Vector3 offset;
		
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
