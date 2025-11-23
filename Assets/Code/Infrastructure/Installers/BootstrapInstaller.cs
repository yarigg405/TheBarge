using Assets.Code.Infrastructure.AssetManagement;
using Assets.Code.Infrastructure.DI;
using Assets.Code.Infrastructure.EntryPoints;
using Assets.Code.Infrastructure.Factory;
using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.GameStates;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Services.Input;
using Assets.Code.Services.PersistentProgress;
using Assets.Code.Services.SaveLoad;
using Assets.Code.StaticData;
using Assets.Code.StaticData.Windows;
using Assets.Code.UI.Elements;
using Assets.Code.UI.Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Assets.Code.Infrastructure.Installers
{
    public sealed class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        [SerializeField] private WindowsStaticData _windowsStaticData;


        protected override void Install()
        {
            RegisterServices();
            RegisterUI();
            RegisterStates();

            Builder.RegisterEntryPoint<BootstrapEntryPoint>();
        }

        private void RegisterServices()
        {
            Builder.Register<SceneLoader>(Lifetime.Singleton).AsImplementedInterfaces();
            Builder.Register<AssetProvider>(Lifetime.Singleton).AsImplementedInterfaces();
            Builder.Register<GameFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            Builder.Register<InputService>(Lifetime.Singleton).AsImplementedInterfaces();
            Builder.Register<SaveLoadService>(Lifetime.Singleton).AsImplementedInterfaces();
            Builder.Register<PersistentProgressService>(Lifetime.Singleton).AsImplementedInterfaces();
            Builder.Register<StaticDataService>(Lifetime.Singleton).AsSelf();
        }

        private void RegisterUI()
        {
            Builder.Register<WindowService>(Lifetime.Singleton).AsSelf();
            Builder.Register<UiFactory>(Lifetime.Singleton).AsSelf();
            Builder.RegisterInstance(_loadingScreen);
            Builder.RegisterInstance(_windowsStaticData);
        }

        private void RegisterStates()
        {
            Builder.Register<GameStateMachine>(Lifetime.Singleton).AsImplementedInterfaces();

            Builder.Register<BootstrapState>(Lifetime.Transient);
            Builder.Register<LoadProgressState>(Lifetime.Transient);
            Builder.Register<LoadSceneState>(Lifetime.Transient);
            Builder.Register<GameLoopState>(Lifetime.Transient);
        }
    }
}