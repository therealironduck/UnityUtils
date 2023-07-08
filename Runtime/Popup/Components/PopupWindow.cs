using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TheRealIronDuck.Runtime.Popup.Components
{
    public class PopupWindow : MonoBehaviour
    {
        #region EXPOSED FIELDS
        
        [SerializeField] private TextMeshProUGUI labelText;
        [SerializeField] private Button confirmButton;
        [SerializeField] private GameObject background;
        [SerializeField] private Graphic[] fadeInTargets;
        [SerializeField] [Range(0f, .5f)] private float loadingStepTime = .05f;
        [SerializeField] [Range(0f, 1f)] private float loadingStepAmount = .1f;
        [SerializeField] private bool persistBetweenScenes;

        #endregion
        
        #region PUBLIC METHODS
        
        public void Show(string text)
        {
            if (persistBetweenScenes)
            {
                DontDestroyOnLoad(gameObject);
            }
            
            labelText.text = text;
            confirmButton.onClick.AddListener(OnConfirm);
            
            StartCoroutine(RoutineFadeIn());
        }
        
        #endregion

        #region PRIVATE METHODS
        
        private IEnumerator RoutineFadeIn()
        {
            var fadeInOriginal = fadeInTargets.ToDictionary(
                target => target.GetInstanceID(), target => target.color.a
            );

            foreach (var target in fadeInTargets)
            {
                var color = target.color;
                color.a = 0;
                target.color = color;
            }
            
            background.SetActive(true);
            var percentage = 0f;

            while (percentage < 1f)
            {
                yield return new WaitForSeconds(loadingStepTime);

                percentage += loadingStepAmount;

                foreach (var target in fadeInTargets)
                {
                    var color = target.color;
                    color.a = fadeInOriginal[target.GetInstanceID()] / 1f * percentage; // max / 1 * percentage
                    target.color = color;
                }
            }
        }
        
        private void OnConfirm()
        {
            confirmButton.onClick.RemoveAllListeners(); // Make sure the user can't click twice
            StartCoroutine(RoutineFadeOutAndDestroy());
        }
    
        private IEnumerator RoutineFadeOutAndDestroy()
        {
            var fadeInOriginal = fadeInTargets.ToDictionary(
                target => target.GetInstanceID(), target => target.color.a
            );

            var percentage = 1f;
            while (percentage > 0f)
            {
                yield return new WaitForSeconds(loadingStepTime);

                percentage -= loadingStepAmount;

                foreach (var target in fadeInTargets)
                {
                    var color = target.color;
                    color.a = fadeInOriginal[target.GetInstanceID()] / 1f * percentage; // max / 1 * percentage
                    target.color = color;
                }
            }
            
            Destroy(gameObject);
        }
        
        #endregion
    }
}