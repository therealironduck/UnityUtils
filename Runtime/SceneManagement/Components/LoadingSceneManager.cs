using System.Collections;
using TheRealIronDuck.Runtime.SceneManagement.Data;
using UniDi;
using UnityEngine;
using UnityEngine.SceneManagement;
#if THEREALIRONDUCK_NETWORKING
using Unity.Netcode;
#endif

namespace TheRealIronDuck.Runtime.SceneManagement.Components
{
    public class LoadingSceneManager : MonoBehaviour
    {
        #region VARIABLES

        [Inject] private readonly LoadingFadeEffect _loadingFadeEffect; 

        #endregion
        
        #region PUBLIC METHODS

        public void LoadScene(string targetScene, LoadSceneOptions options = default)
        {
            StartCoroutine(RoutineLoading(targetScene, options));
        }
        
        #endregion

        #region PRIVATE METHODS

        private IEnumerator RoutineLoading(string targetScene, LoadSceneOptions options)
        {
            if (options is { SkipLoadingScreen: false, SkipFadeIn: false })
            {
                _loadingFadeEffect.FadeIn();
                yield return new WaitUntil(() => _loadingFadeEffect.CanLoad);
            }

            if (options.IsNetworkSession)
            {
#if THEREALIRONDUCK_NETWORKING
                if (NetworkManager.Singleton.IsServer)
                {
                    LoadSceneNetwork(targetScene, options.Mode);
                }
#else
                Debug.LogError("Please add the `THEREALIRONDUCK_NETWORKING` scripting symbol to use Network Methods");
#endif
            }
            else
            {
                LoadSceneLocal(targetScene, options.Mode);
            }

            if (!options.SkipLoadingScreen)
            {
                yield return new WaitForSeconds(1f);
                _loadingFadeEffect.FadeOut();
            }
        }

        private void LoadSceneLocal(string targetScene, LoadSceneMode mode)
        {
            SceneManager.LoadScene(targetScene, mode);
        }

#if THEREALIRONDUCK_NETWORKING
        private void LoadSceneNetwork(string targetScene, LoadSceneMode mode)
        {
            NetworkManager.Singleton.SceneManager.LoadScene(targetScene, mode);
        }
#endif
        
        #endregion
    }
}