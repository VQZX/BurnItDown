using System;
using System.Collections.Generic;

namespace Flusk.Utility
{
    public static class ListUtility
    {
        public static void Run<T>(this List<T> list, Action<T> action)
        {
            foreach (T item in list)
            {
                action(item);
            }
        }
    }
}