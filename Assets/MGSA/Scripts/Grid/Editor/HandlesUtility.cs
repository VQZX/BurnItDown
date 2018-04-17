using System;
using UnityEditor;

namespace Grid.Editor
{
    public static class HandlesUtility
    {
        public static void HandlesGUI(Action guiDraw)
        {
            Handles.BeginGUI();
            guiDraw.Invoke();
            Handles.EndGUI();
        }
    }
}