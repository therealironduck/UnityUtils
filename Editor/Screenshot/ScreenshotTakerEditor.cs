using TheRealIronDuck.Runtime.Screenshot.Components;
using UnityEditor;
using UnityEngine;

namespace TheRealIronDuck.Editor.Screenshot
{
    [CustomEditor(typeof(ScreenshotTaker))]
    public class ScreenshotTakerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox(
                "The package contains a ready-to-use prefab for the capture camera.",
                MessageType.Info
            );
            
            base.OnInspectorGUI();
            
            if (GUILayout.Button("Capture screenshot"))
            {
                ((ScreenshotTaker) target).Capture();
                
                AssetDatabase.Refresh();
            }
        }
    }
}