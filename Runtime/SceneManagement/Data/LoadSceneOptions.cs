using UnityEngine.SceneManagement;

namespace TheRealIronDuck.Runtime.SceneManagement.Data
{
    public struct LoadSceneOptions
    {
        public readonly bool IsNetworkSession;
        public readonly bool SkipLoadingScreen;
        public readonly bool SkipFadeIn;
        public readonly LoadSceneMode Mode;

        public LoadSceneOptions(
            bool isNetworkSession = true,
            bool skipLoadingScreen = false,
            bool skipFadeIn = false,
            LoadSceneMode mode = LoadSceneMode.Single
        )
        {
            IsNetworkSession = isNetworkSession;
            SkipLoadingScreen = skipLoadingScreen;
            SkipFadeIn = skipFadeIn;
            Mode = mode;
        }
    }
}