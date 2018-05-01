using System;
using UnityEngine;

namespace Flusk.Utility
{
    public class Vector2IntUtil
    {
        private Vector2Int vector2Int;

        public Vector2IntUtil(Vector2Int vector2Int)
        {
            this.vector2Int = vector2Int;
        }

        public static void Run(Vector2Int data, Action<int, int> action)
        {
            var container = new Vector2IntUtil(data);
            container.Run(action);
        }
        
        public void Run(Action<int , int> action)
        {
            for (int i = 0; i < vector2Int.x; i++)
            {
                for (int j = 0; j < vector2Int.y; j++)
                {
                    action(i, j);
                }
            }
        }

        
    }
}