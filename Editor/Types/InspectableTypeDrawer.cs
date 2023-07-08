﻿using System;
using System.Linq;
using TheRealIronDuck.Runtime.Types;
using UnityEditor;
using UnityEngine;

namespace TheRealIronDuck.Editor.Types
{
    [CustomPropertyDrawer(typeof(InspectableType<>))]
    public class InspectableTypeDrawer : PropertyDrawer
    {
        #region VARIABLES
        
        private Type[] _derivedTypes;
        private GUIContent[] _optionLabels;
        private int _selectedIndex;
        
        #endregion

        #region OVERRIDDEN METHODS
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var storedProperty = property.FindPropertyRelative("qualifiedName");
            string qualifiedName = storedProperty.stringValue;

            if (_optionLabels == null)
            {
                Initialize(property, storedProperty);
            } else if (_selectedIndex == _derivedTypes.Length)
            {
                if (qualifiedName != "null")
                {
                    UpdateIndex(storedProperty);
                }
            }
            else
            {
                if (qualifiedName != _derivedTypes[_selectedIndex].AssemblyQualifiedName)
                {
                    UpdateIndex(storedProperty);
                }
            }

            var propLabel = EditorGUI.BeginProperty(position, label, property);
            EditorGUI.BeginChangeCheck();

            _selectedIndex = EditorGUI.Popup(position, propLabel, _selectedIndex, _optionLabels);

            if (EditorGUI.EndChangeCheck())
            {
                storedProperty.stringValue = _selectedIndex < _derivedTypes.Length ? _derivedTypes[_selectedIndex].AssemblyQualifiedName : "null";
            }
            
            EditorGUI.EndProperty();
        }
        
        #endregion

        #region PRIVATE METHODS
        
        private void Initialize(SerializedProperty property, SerializedProperty stored)
        {
            var baseTypeProperty = property.FindPropertyRelative("baseTypeName");
            var baseType = Type.GetType(baseTypeProperty.stringValue);

            _derivedTypes = FindAllDerivedTypes(baseType);

            if (_derivedTypes.Length == 0)
            {
                _optionLabels = new[] { new GUIContent($"No types derived from {baseType?.Name} found") };
                return;
            }

            _optionLabels = new GUIContent[_derivedTypes.Length + 1];
            for (var i = 0; i < _derivedTypes.Length; i++)
            {
                _optionLabels[i] = new GUIContent(_derivedTypes[i].Name);
            }

            _optionLabels[_derivedTypes.Length] = new GUIContent("null");

            UpdateIndex(stored);
        }

        private void UpdateIndex(SerializedProperty stored)
        {
            var qualifiedName = stored.stringValue;

            for (var i = 0; i < _derivedTypes.Length; i++)
            {
                if (_derivedTypes[i].AssemblyQualifiedName != qualifiedName)
                {
                    continue;
                }
                
                _selectedIndex = i;
                return;
            }

            _selectedIndex = _derivedTypes.Length;
            stored.stringValue = "null";
        }

        private static Type[] FindAllDerivedTypes(Type baseType)
        {
            return baseType.Assembly.GetTypes().Where(
                t => t != baseType && baseType.IsAssignableFrom(t)
            ).ToArray();
        }
        
        #endregion
    }
}