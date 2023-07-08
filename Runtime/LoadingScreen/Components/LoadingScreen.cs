using TMPro;
using UnityEngine;

namespace TheRealIronDuck.Runtime.LoadingScreen.Components
{
    public class LoadingScreen : MonoBehaviour
    {
        #region EXPOSED FIELDS

        [SerializeField]
        private TextMeshProUGUI loadingText;

        [SerializeField]
        private GameObject loadingBackground;

        #endregion

        #region PUBLIC METHODS

        public void Show(string text)
        {
            loadingText.text = text;
            loadingBackground.SetActive(true);
            // TODO: Add fade
        }

        public void Change(string newText)
        {
            loadingText.text = newText;
        }
        
        public void Hide()
        {
            loadingBackground.SetActive(false);
        }

        #endregion
    }
}