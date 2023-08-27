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

        #endregion

        #region VARIABLES

        private float _secondTimer;

        #endregion

        #region LIFECYCLE METHODS

        public void Tick()
        {
            OnTickFrame?.Invoke();
            
            _secondTimer -= Time.deltaTime;
            if (_secondTimer > 0)
            {
                return;
            }
            
            _secondTimer = 1;
            OnTickSecond?.Invoke();
        }

        #endregion
    }
}