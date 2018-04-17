using UnityEngine;

namespace Flusk.Animation
{
    public class AnimationWrapper
    {
        protected Animator animator;

        public AnimationWrapper(GameObject gameObject)
        {
            animator = gameObject.GetComponentInChildren<Animator>();
        }

        public AnimationWrapper(Animator attachedAnimator)
        {
            animator = attachedAnimator;
        }
    }
}