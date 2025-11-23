using Assets.Code.CameraLogic;
using Assets.Code.Infrastructure.Factory;
using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.States.StatesInfrastructure;
using Assets.Code.Services.PersistentProgress;
using Assets.Code.UI.Elements;
using Assets.Code.UI.Services;
using UnityEngine;


namespace Assets.Code.Infrastructure.States.GameStates
{
    internal sealed class LoadSceneState : GamePayloadState<string>
    {
        private readonly IStateMachine _stateMachine;
        private readonly IScenesLoader _scenesLoader;
        private readonly LoadingScreen _loadingScreen;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;
        private readonly UiFactory _uiFactory;

        private const string _playerSpawnPointTag = "PlayerSpawnPoint";

        public LoadSceneState(IStateMachine stateMachine, IScenesLoader scenesLoader,
            LoadingScreen loadingScreen, IGameFactory gameFactory,
            IPersistentProgressService progressService, UiFactory uiFactory)
        {
            _stateMachine = stateMachine;
            _scenesLoader = scenesLoader;
            _loadingScreen = loadingScreen;
            _gameFactory = gameFactory;
            _progressService = progressService;
            _uiFactory = uiFactory;
        }

        public override void Enter(string sceneName)
        {
            _loadingScreen.Show();
            _gameFactory.Cleanup();
            _scenesLoader.LoadScene(sceneName, OnLoaded);
        }

        public override void Exit()
        {
            _uiFactory.CreateUiRoot();
            _loadingScreen.Hide();

        }

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();
            _stateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders()
        {
            foreach (var prRd in _gameFactory.ProgressReaders)
            {
                prRd.LoadProgress(_progressService.Progress);
            }
        }

        private void InitGameWorld()
        {
            GameObject player = _gameFactory.CreatePlayer(GameObject.FindGameObjectWithTag(_playerSpawnPointTag));
            SetCameraTarget(player);

            _gameFactory.CreateHud();
        }

        private static void SetCameraTarget(GameObject player)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(player);
        }
    }
}
