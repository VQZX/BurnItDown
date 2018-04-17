using System;
using MGSA.Pathing;
using UnityEditor;
using UnityEngine;

namespace Pathing.Editor
{
    public class PathAnimator
    {
        public float Speed;
        public PathPoint Begin, End;
        public float Size;

        private double beginTime;

        private Vector3 currentPosition;

        public PathAnimator(float speed, PathPoint begin, PathPoint end, float size)
        {
            Speed = speed;
            Begin = begin;
            End = end;
            Size = size;

            beginTime = EditorApplication.timeSinceStartup;
        }

        public void Update()
        {
            double difference = (EditorApplication.timeSinceStartup - beginTime) * Speed;
            currentPosition = Vector3.Lerp(Begin.point, End.point, (float) difference);

            if (difference >= 1)
            {
                beginTime = EditorApplication.timeSinceStartup;
            }
            
            CreateArrow();
        }

        private void CreateArrow()
        {
            Handles.SphereHandleCap(
                0,
                currentPosition,
                Quaternion.identity,
                Size,
                EventType.Repaint
            );
        }
    }
}