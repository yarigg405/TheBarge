using Assets.Code.CameraLogic;
using Assets.Code.Infrastructure.Factory;
using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.States.StatesInfrastructure;
using Assets.Code.UI;
using UnityEngine;


namespace Assets.Code.Infrastructure.States.GameStates
{
    internal sealed class LoadSceneState : GamePayloadState<string>
    {
        private readonly IStateMachine _stateMachine;
        private readonly IScenesLoader _scenesLoader;
        private readonly LoadingScreen _loadingScreen;
        private readonly IGameFactory _gameFactory;

        private const string _playerSpawnPointTag = "PlayerSpawnPoint";

        public LoadSceneState(IStateMachine stateMachine, IScenesLoader scenesLoader,
            LoadingScreen loadingScreen, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _scenesLoader = scenesLoader;
            _loadingScreen = loadingScreen;
            _gameFactory = gameFactory;
        }

        public override void Enter(string sceneName)
        {
            _loadingScreen.Show();
            _scenesLoader.LoadScene(sceneName, OnLoaded);
        }

        public override void Exit()
        {
            _loadingScreen.Hide();
        }

        private void OnLoaded()
        {
            GameObject player = _gameFactory.CreatePlayer(GameObject.FindGameObjectWithTag(_playerSpawnPointTag));
            SetCameraTarget(player);

            _gameFactory.CreateHud();
            _stateMachine.Enter<GameLoopState>();
        }


        private static void SetCameraTarget(GameObject player)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(player);
        }
    }
}
