﻿using UnityEditor;
using UnityEngine;

namespace BurnItDown.Environment.Grids.Editor
{
    [CustomEditor(typeof(GroundBuilder))]
    public class GroundBuilderEditor : UnityEditor.Editor
    {
        private GroundBuilder builder;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Generate"))
            {
                builder.GenerateBlocks();
            }

            if (GUILayout.Button("Destroy"))
            {
                builder.DestroyBlocks();
            }
        }

        private void OnEnable()
        {
            builder = (GroundBuilder) target;
        }
        
    }
}