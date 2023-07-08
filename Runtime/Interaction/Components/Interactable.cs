using UnityEngine;
using UnityEngine.Events;

namespace TheRealIronDuck.Runtime.Interaction.Components
{
    public class Interactable : MonoBehaviour
    {
        #region EVENTS

        public readonly UnityEvent<Interactor> OnInteract = new();
        public readonly UnityEvent<Interactor> OnInteractEnter = new();
        public readonly UnityEvent<Interactor> OnInteractExit = new();

        #endregion

        #region EXPOSED FIELDS

        [SerializeField] private KeyCode key;

        #endregion

        #region VARIABLES

        private Interactor _interactor;

        #endregion
        
        #region LIFECYCLE METHODS

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<Interactor>(out var interactor))
            {
                return;
            }

            _interactor = interactor;
            OnInteractEnter.Invoke(_interactor);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent<Interactor>(out var interactor))
            {
                return;
            }

            if (_interactor != interactor)
            {
                return;
            }

            _interactor = null;
            OnInteractExit.Invoke(_interactor);
        }

        private void Update()
        {
            if (!Input.GetKeyDown(key) || _interactor == null)
            {
                return;
            }
            
            OnInteract.Invoke(_interactor);
        }

        #endregion
    }
}