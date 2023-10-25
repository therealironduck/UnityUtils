using UniDi;
using UnityEngine;
using UnityEngine.Events;

namespace TheRealIronDuck.Runtime.Helper.Systems
{
    public class Ticker : ITickable
    {
        #region EVENTS

        public readonly UnityEvent OnTickFrame = new();
        public readonly UnityEvent OnTickSecond = new();
        public readonly UnityEvent OnTickHalfSecond = new();

        #endregion

        #region VARIABLES

        private float _secondTimer;
        private float _halfSecondTimer;

        #endregion

        #region LIFECYCLE METHODS

        public void Tick()
        {
            OnTickFrame?.Invoke();
            
            _secondTimer -= Time.deltaTime;
            _halfSecondTimer -= Time.deltaTime;
            
            if (_secondTimer <= 0)
            {
                _secondTimer = 1;
                OnTickSecond?.Invoke();
            }

            if (_halfSecondTimer <= 0)
            {
                _halfSecondTimer = .5f;
                OnTickHalfSecond?.Invoke();
            }
        }

        #endregion
    }
}