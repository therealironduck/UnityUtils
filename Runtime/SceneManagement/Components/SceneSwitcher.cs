using TheRealIronDuck.Runtime.SceneManagement.Data;
using UnityEngine;
using Zenject;

namespace TheRealIronDuck.Runtime.SceneManagement.Components
{
    public class SceneSwitcher : MonoBehaviour
    {
        #region EXPOSED FIELDS
        
        [SerializeField] private string targetScene;
        
        #endregion
        
        #region VARIABLES
        
        [Inject] private readonly LoadingSceneManager _loadingSceneManager;
        
        #endregion

        #region LIFECYCLE METHODS
        
        private void Start()
        {
            _loadingSceneManager.LoadScene(targetScene, new LoadSceneOptions(
                isNetworkSession: false,
                skipLoadingScreen: true
            ));
        }
        
        #endregion
    }
}