using JetBrains.Annotations;
using UnityEngine;
#if THEREALIRONDUCK_NEW_INPUT
using UnityEngine.InputSystem;
#endif

namespace TheRealIronDuck.Runtime.Helper
{
    public static class CameraHelper
    {
        #region PUBLIC METHODS

        public static Vector3? RayFromMouseToGround(Camera camera, LayerMask layerMask)
        {
#if THEREALIRONDUCK_NEW_INPUT
            var ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
#else
            var ray = camera.ScreenPointToRay(Input.mousePosition);
#endif
            if (!Physics.Raycast(ray, out var hit, 1000f, layerMask))
            {
                return null;
            }

            return hit.point;
        }

        [CanBeNull]
        public static Transform RayFromMouseToTarget(Camera camera, LayerMask layerMask)
        {
#if THEREALIRONDUCK_NEW_INPUT
            var ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
#else
            var ray = camera.ScreenPointToRay(Input.mousePosition);
#endif

            return Physics.Raycast(ray, out var hit, 1000f, layerMask) ? hit.transform : null;
        }

        #endregion 
    }
}