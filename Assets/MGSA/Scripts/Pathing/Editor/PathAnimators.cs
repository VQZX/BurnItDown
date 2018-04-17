using System.Collections.Generic;
using MGSA.Pathing;

namespace Pathing.Editor
{
    public class PathAnimators
    {
        private List<PathAnimator> animators;
        private PathController PathController;
        private float Speed;
        private float Size;
        private bool Wrap;

        public PathAnimators(PathController path, float speed, float size, bool wrap = false)
        {
            animators = new List<PathAnimator>();
            PathController = path;
            Speed = speed;
            Size = size;
            Wrap = wrap;
            Initialize();
        }

        public void Update()
        {
            foreach (var animator in animators)
            {
                animator.Update();
            }
        }
        
        
        private void Add(PathAnimator animator)
        {
            animators.Add(animator);
        }

        private void Remove(PathAnimator animator)
        {
            animators.Remove(animator);
            animator = null;
        }

        private void Initialize()
        {
            CreatePathAnimator(PathController.path.First);
        }

        private void CreatePathAnimator(PathPoint point)
        {
            if (!point.IsLeaf)
            {
                foreach (PathPoint child in point.nextPathPoints)
                {
                    var animator = new PathAnimator(Speed,  point, child, Size);
                    Add(animator);
                    CreatePathAnimator(child);
                }
            }
            else if (Wrap)
            {
                var animator = new PathAnimator(Speed,  point, PathController.path.First, Size);
                Add(animator);   
            }
        }
    }
}