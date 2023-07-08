using UnityEngine;

namespace TheRealIronDuck.Runtime.Helper
{
    public static class VectorHelper
    {
        #region PUBLIC METHODS
        
        public static T GetClosestTarget<T>(T[] targets, Vector3 position) where T : Component
        {
            var closestDistance = float.MaxValue;
            T closestTarget = null;

            foreach (var target in targets)
            {
                if (target == null)
                {
                    continue;
                }
                
                var distance = Vector3.Distance(position, target.transform.position);
                if (distance > closestDistance)
                {
                    continue;
                }

                closestDistance = distance;
                closestTarget = target;
            }

            return closestTarget;
        }

        public static Vector3 GetDirectionVectorFromTargetToMouse(Vector3 position, Camera camera = null)
        {
            camera = camera ? camera : Camera.main;
            if (!camera)
            {
                Debug.LogError("No camera given or main camera found!");
                return default;
            }
            
            var mousePosition = Input.mousePosition;
            mousePosition.z = camera.transform.position.y;
            var worldMousePosition = camera.ScreenToWorldPoint(mousePosition);
            var direction = worldMousePosition - position;
            direction.y = 0;
            
            return direction.normalized;
        }

        public static Vector3 GetDirectionVectorBetweenPoints(Vector3 startPoint, Vector3 endPoint)
        {
            return (endPoint - startPoint).normalized;
        }
        
        #endregion
    }
}