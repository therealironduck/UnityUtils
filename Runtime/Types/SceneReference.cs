using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TheRealIronDuck.Runtime.Types
{
    /// <summary>
    /// Stolen from: https://github.com/Tymski/SceneReference/blob/master/Scripts/SceneReference.cs
    ///
    /// A wrapper that allows to attach scenes in Unity inspector.
    /// </summary>
    [Serializable]
    public class SceneReference : ISerializationCallbackReceiver
    {
#if UNITY_EDITOR
        /// <summary>
        /// Only in editor a field to allow choosing a scene.
        /// </summary>
        [SerializeField] Object sceneAsset;

        /// <summary>
        /// A simple check if the scene is valid. (Is it set and is the asset an actual
        /// scene?)
        /// </summary>
        bool IsValidSceneAsset
        {
            get { return sceneAsset != null && sceneAsset is SceneAsset; }
        }
#endif

        /// <summary>
        /// The actual scene path. This will be stored in the object at runtime.
        /// </summary>
        [SerializeField] string scenePath = string.Empty;

        /// <summary>
        /// Returns the scene path. In editor mode it uses the actual asset
        /// and in runtime the serialized scene path.
        /// </summary>
        public string ScenePath
        {
            get
            {
#if UNITY_EDITOR
                return GetScenePathFromAsset();
#else
                return scenePath;
#endif
            }

            set
            {
                scenePath = value;
#if UNITY_EDITOR
                sceneAsset = GetSceneAssetFromPath();
#endif
            }
        }

        /// <summary>
        /// Allows to use the SceneReference object as a string directly.
        /// This allows stuff like:
        /// SceneManager.LoadScene(mySceneReference);
        /// </summary>
        /// <returns>The scene path as a string</returns>
        public static implicit operator string(SceneReference sceneReference)
        {
            return sceneReference.ScenePath;
        }

        /// <summary>
        /// Handle serialization (editor only)
        /// </summary>
        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            HandleBeforeSerialize();
#endif
        }

        /// <summary>
        /// Handle deserialization (editor only)
        /// </summary>
        public void OnAfterDeserialize()
        {
#if UNITY_EDITOR
            EditorApplication.update += HandleAfterDeserialize;
#endif
        }


#if UNITY_EDITOR
        /// <summary>
        /// Returns the scene asset based on the configured scene path.
        /// </summary>
        public SceneAsset GetSceneAssetFromPath()
        {
            return string.IsNullOrEmpty(scenePath) ? null : AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
        }

        /// <summary>
        /// Return the scene path based on the set asset.
        /// </summary>
        public string GetScenePathFromAsset()
        {
            return sceneAsset == null ? string.Empty : AssetDatabase.GetAssetPath(sceneAsset);
        }

        /// <summary>
        /// Handles serialization.
        /// </summary>
        void HandleBeforeSerialize()
        {
            if (!IsValidSceneAsset && !string.IsNullOrEmpty(scenePath))
            {
                sceneAsset = GetSceneAssetFromPath();
                if (sceneAsset == null) scenePath = string.Empty;

                EditorSceneManager.MarkAllScenesDirty();
                return;
            }

            scenePath = GetScenePathFromAsset();
        }

        /// <summary>
        /// Handles deserialization.
        /// </summary>
        void HandleAfterDeserialize()
        {
            EditorApplication.update -= HandleBeforeSerialize;

            if (IsValidSceneAsset) return;
            if (string.IsNullOrEmpty(scenePath)) return;

            sceneAsset = GetSceneAssetFromPath();
            if (!sceneAsset) scenePath = string.Empty;
            if (!Application.isPlaying) EditorSceneManager.MarkAllScenesDirty();
        }
#endif
    }
}
