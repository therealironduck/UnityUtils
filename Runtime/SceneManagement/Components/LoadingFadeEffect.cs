using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TheRealIronDuck.Runtime.SceneManagement.Components
{
    public class LoadingFadeEffect : MonoBehaviour
    {
        #region EXPOSED FIELDS
        
        [SerializeField]
        private Image loadingBackground;

        [SerializeField] [Range(0f, .5f)] private float loadingStepTime = .1f;
        [SerializeField] [Range(0f, 1f)] private float loadingStepAmount = .1f;
        
        #endregion
        
        #region VARIABLES 
        
        public bool CanLoad { get; private set; }
        
        #endregion

        #region PUBLIC METHODS
        
        public void FadeIn() => StartCoroutine(RoutineFadeInEffect());
        public void FadeOut() => StartCoroutine(RoutineFadeOutEffect());
        
        #endregion
        
        #region PRIVATE METHODS
        
        private IEnumerator RoutineFadeInEffect()
        {
            CanLoad = false;
            
            var backgroundColor = loadingBackground.color;
            backgroundColor.a = 0;
            loadingBackground.color = backgroundColor;
            loadingBackground.gameObject.SetActive(true);

            while (backgroundColor.a <= 1f)
            {
                yield return new WaitForSeconds(loadingStepTime);

                backgroundColor.a += loadingStepAmount;
                loadingBackground.color = backgroundColor;
            }

            CanLoad = true;
        }

        private IEnumerator RoutineFadeOutEffect()
        {
            CanLoad = false;

            var backgroundColor = loadingBackground.color;
            backgroundColor.a = 1;
            loadingBackground.color = backgroundColor;
            loadingBackground.gameObject.SetActive(true);

            while (backgroundColor.a >= 0f)
            {
                yield return new WaitForSeconds(loadingStepTime);

                backgroundColor.a -= loadingStepAmount;
                loadingBackground.color = backgroundColor;
            }

            loadingBackground.gameObject.SetActive(false);
        }
        
        #endregion
    }
}