using TheRealIronDuck.Runtime.Helper.Systems;
using TheRealIronDuck.Runtime.SceneManagement.Components;
using UniDi;
using UnityEngine;

namespace TheRealIronDuck.Runtime
{
    public class TheRealIronDuckInstaller : MonoInstaller<TheRealIronDuckInstaller>
    {
        [SerializeField] private GameObject loadingScenePrefab;
        [SerializeField] private GameObject popupPrefab;
        [SerializeField] private GameObject loadingScreenPrefab;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            Container.Bind(typeof(LoadingFadeEffect), typeof(LoadingSceneManager))
                .FromComponentInNewPrefab(loadingScenePrefab)
                .AsSingle();

            Container.Bind<LoadingScreen.Components.LoadingScreen>()
                .FromComponentInNewPrefab(loadingScreenPrefab)
                .AsSingle();

            Container.Bind<Popup.Systems.Popup>().AsSingle();
            Container.Bind<GameObject>().WithId("TheRealIronDuck_PopupPrefab").FromInstance(popupPrefab);

            Container.BindInterfacesAndSelfTo<Ticker>().AsSingle();
        }
    }
}