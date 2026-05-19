using UnityEngine;

namespace TheRealIronDuck.Runtime.Helper.Components
{
    public class Rotate : MonoBehaviour
    {
        #region EXPOSED FIELDS

        [SerializeField] Vector3 rotationSpeed;

        #endregion

        #region LIFECYCLE METHODS

        void Update()
        {
            transform.Rotate(rotationSpeed * Time.deltaTime);
        }

        #endregion
    }
}