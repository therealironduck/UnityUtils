using TheRealIronDuck.Runtime.Types;
using UnityEditor;
using UnityEngine;

namespace TheRealIronDuck.Editor.Types
{
    [CustomPropertyDrawer(typeof(SceneReference))]
    public class SceneReferenceDrawer : PropertyDrawer
    {
        // The exact name of the asset Object variable in the SceneReference object
        const string SceneAssetPropertyString = "sceneAsset";

        // The exact name of the scene Path variable in the SceneReference object
        const string ScenePathPropertyString = "scenePath";

        readonly static RectOffset BoxPadding = EditorStyles.helpBox.padding;

        const float PadSize = 0f;
        const float FooterHeight = 0f;

        readonly static float LineHeight = EditorGUIUtility.singleLineHeight;
        readonly static float PaddedLine = LineHeight + PadSize;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.serializedObject.isEditingMultipleObjects)
            {
                GUI.Label(position, "Scene multiediting not supported");
                return;
            }

            var sceneAssetProperty = property.FindPropertyRelative(SceneAssetPropertyString);
            var scenePathProperty = property.FindPropertyRelative(ScenePathPropertyString);
            var sceneControlID = GUIUtility.GetControlID(FocusType.Passive);
            EditorGUI.BeginChangeCheck();
            {
                sceneAssetProperty.objectReferenceValue = EditorGUI.ObjectField(position, label, sceneAssetProperty.objectReferenceValue, typeof(SceneAsset), false);
            }
            if (EditorGUI.EndChangeCheck())
            {
                var selectedAsset = sceneAssetProperty.objectReferenceValue as SceneAsset;
                scenePathProperty.stringValue = selectedAsset != null
                    ? AssetDatabase.GetAssetPath(selectedAsset)
                    : string.Empty;
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return LineHeight;
        }
    }
}
