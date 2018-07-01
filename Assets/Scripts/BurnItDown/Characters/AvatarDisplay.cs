using Flusk.Animation;
using UnityEngine;

namespace BurnItDown.Characters
{
    public class AvatarDisplay : BurnItDownBehaviour
    {

        public AvatarAnimator Animator { get; private set; }

        private float defaultFacingSign;

        protected virtual void Awake()
        {   
            Animator = new AvatarAnimator(gameObject);
            Animator.Entrance();
            defaultFacingSign = Mathf.Sign(transform.localScale.x);
        }

        public void AdjustLocalPosition(Vector3 offset)
        {
            transform.localPosition += offset;
        }

        public void ResetLocalPosition()
        {
            transform.localPosition = Vector3.zero;
        }

        public void FaceRight()
        {
            Vector3 scale = transform.localScale;
            scale.x = defaultFacingSign * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

        public void FaceLeft()
        {
            Vector3 scale = transform.localScale;
            scale.x = -defaultFacingSign * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }
    
    public class AvatarAnimator : AnimationWrapper
    {
        private abstract class Params
        {
            public const string DEATH = "Death";
            public const string JUMP = "Jump";
            public const string SPEED = "Speed";
            public const string SHOOT = "Shoot";
            public const string ENTRANCE = "Entrance";
        }

        public bool Death
        {
            get { return animator.GetBool(Params.DEATH); }
            set {animator.SetBool(Params.DEATH, value);}
        }

        public void Jump()
        {
            animator.SetTrigger(Params.JUMP);
        }

        public void Entrance()
        {
            animator.SetTrigger(Params.ENTRANCE);
        }

        public float Speed
        {
            get { return animator.GetFloat(Params.SPEED); }
            set {animator.SetFloat(Params.SPEED, value);}
        }
        
        public bool Shoot
        {
            get { return animator.GetBool(Params.SHOOT); }
            set {animator.SetBool(Params.SHOOT, value);}
        }

        public AvatarAnimator(GameObject gameObject) : base(gameObject)
        {
        }

        public AvatarAnimator(Animator attachedAnimator) : base(attachedAnimator)
        {
        }
        
    }
}