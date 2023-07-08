using TheRealIronDuck.Runtime.Helper.Components;
using UnityEditor;
using UnityEngine;

namespace TheRealIronDuck.Editor.Helper
{
    [CustomEditor(typeof(RemoveAllChildren))]
    public class RemoveAllChildrenButtonEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            if (GUILayout.Button("Remove All Children"))
            {
                ((RemoveAllChildren) target).RemoveAll();
            }
        }
    }
}