using UnityEngine;

namespace TheRealIronDuck.Runtime.Helper.Components
{
    public class Rotate : MonoBehaviour
    {
        #region EXPOSED FIELDS

        [SerializeField] private Vector3 rotationSpeed;

        #endregion

        #region LIFECYCLE METHODS

        private void Update()
        {
            transform.Rotate(rotationSpeed * Time.deltaTime);
        }

        #endregion
    }
}