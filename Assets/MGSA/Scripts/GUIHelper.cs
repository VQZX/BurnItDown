using System;
using UnityEngine;

namespace MGSA
{
    public static class GUIHelper
    {
        public static void HorizontalGroup(Action action)
        {
            GUILayout.BeginHorizontal();
            action.Invoke();
            GUILayout.EndHorizontal();
        }
    
        public static void VerticalGroup(Action action)
        {
            GUILayout.BeginVertical();
            action.Invoke();
            GUILayout.EndVertical();
        }
    }
}