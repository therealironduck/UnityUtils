using TheRealIronDuck.Runtime.Interaction.Components;
using UnityEditor;

namespace TheRealIronDuck.Editor.Interaction
{
    [UnityEditor.CustomEditor(typeof(Interactable))]
    public class InteractableEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox(
                "You need to add the `Interactor` component to the player for this to work. Also you need"
                + " add a trigger collider to this game object.",
                MessageType.Info
            );

            EditorGUILayout.HelpBox(
                "If you want to add an indicator, you'll may want to add a child game object with the " +
                "`InteractorIndicator` component.",
                MessageType.Info
            );

            base.OnInspectorGUI();
        }
    }
}