using UnityEngine;

namespace TheRealIronDuck.Runtime.Helper
{
    public static class CameraHelper
    {
        #region PUBLIC METHODS
        
        public static Vector3? RayFromMouseToGround(Camera camera, LayerMask layerMask)
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hit, 1000f, layerMask))
            {
                return null;
            }
            
            return hit.point;
        }
        
        #endregion
    }
}