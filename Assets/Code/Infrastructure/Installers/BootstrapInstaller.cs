using Assets.Code.Infrastructure.AssetManagement;
using Assets.Code.Infrastructure.DI;
using Assets.Code.Infrastructure.EntryPoints;
using Assets.Code.Infrastructure.Factory;
using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.GameStates;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Services.Input;
using Assets.Code.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Assets.Code.Infrastructure.Installers
{
    public sealed class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreen _loadingScreen;


        protected override void Install()
        {
            Builder.RegisterInstance(_loadingScreen);

            Builder.Register<SceneLoader>(Lifetime.Singleton).AsImplementedInterfaces();
            Builder.Register<GameStateMachine>(Lifetime.Singleton).AsImplementedInterfaces();
            Builder.Register<AssetProvider>(Lifetime.Singleton).AsImplementedInterfaces();
            Builder.Register<GameFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            Builder.Register<InputService>(Lifetime.Singleton).AsImplementedInterfaces();

            RegisterStates();

            Builder.RegisterEntryPoint<BootstrapEntryPoint>();
        }

        private void RegisterStates()
        {
            Builder.Register<BootstrapState>(Lifetime.Transient);
            Builder.Register<LoadSceneState>(Lifetime.Transient);
            Builder.Register<GameLoopState>(Lifetime.Transient);
        }
    }
}