using Assets.Code.CameraLogic;
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

        private const string _playerPrefabPath = "PlayerShip";
        private const string _hudPrefabPath = "UI/Hud";
        private const string _playerSpawnPointTag = "PlayerSpawnPoint";

        public LoadSceneState(IStateMachine stateMachine, IScenesLoader scenesLoader,
            LoadingScreen loadingScreen)
        {
            _stateMachine = stateMachine;
            _scenesLoader = scenesLoader;
            _loadingScreen = loadingScreen;
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
            var spawnPoint = GameObject.FindGameObjectWithTag(_playerSpawnPointTag);
            var player = Instantiate(_playerPrefabPath, spawnPoint.transform.position);
            SetCameraTarget(player);

            Instantiate(_hudPrefabPath, Vector3.zero);

            _stateMachine.Enter<GameLoopState>();
        }

        private static void SetCameraTarget(GameObject player)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(player);
        }

        private static GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(_playerPrefabPath);
            return GameObject.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}
