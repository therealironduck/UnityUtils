using TheRealIronDuck.Runtime.Popup.Components;
using UniDi;
using UnityEngine;

namespace TheRealIronDuck.Runtime.Popup.Systems
{
    public class Popup
    {
        #region VARIABLES
        
        [Inject(Id = "TheRealIronDuck_PopupPrefab")]
        private GameObject _popupPrefab;
        
        #endregion

        #region PUBLIC METHODS
        
        public void Show(string message)
        {
            var popupGo = Object.Instantiate(_popupPrefab);
            popupGo.GetComponent<PopupWindow>().Show(message);
        }
        
        #endregion
    }
}