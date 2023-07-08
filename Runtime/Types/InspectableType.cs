using System;
using UnityEngine;

namespace TheRealIronDuck.Runtime.Types
{
    /**
     * @see https://gamedev.stackexchange.com/questions/203385/how-use-inspector-to-select-a-system-type-not-an-instance-of-classes-inheritin
     */
    [Serializable]
    public class InspectableType<T> : ISerializationCallbackReceiver
    {
        #region EXPOSED FIELDS

        [SerializeField] private string qualifiedName;

#if UNITY_EDITOR
        [SerializeField] private string baseTypeName;
#endif

        #endregion

        #region VARIABLES

        private Type _storedType;

        #endregion

        #region LIFECYCLE METHODS

        public InspectableType(Type typeToStore)
        {
            _storedType = typeToStore;
        }

        #endregion

        #region OVERRIDDEN METHODS

        public override string ToString()
        {
            return _storedType == null ? string.Empty : _storedType.Name;
        }

        #endregion

        #region PUBLIC METHODS

        public void OnBeforeSerialize()
        {
            if (_storedType == null)
            {
                return;
            }

            qualifiedName = _storedType.AssemblyQualifiedName;

#if UNITY_EDITOR
            baseTypeName = typeof(T).AssemblyQualifiedName;
#endif
        }

        public void OnAfterDeserialize()
        {
            if (string.IsNullOrEmpty(qualifiedName) || qualifiedName == "null")
            {
                _storedType = null;
                return;
            }

            _storedType = Type.GetType(qualifiedName);
        }

        public static implicit operator Type(InspectableType<T> t) => t._storedType;
        public static implicit operator InspectableType<T>(Type t) => new(t);

        #endregion
    }
}