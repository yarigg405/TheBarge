using Assets.Code.Data;
using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.States.StatesInfrastructure;
using Assets.Code.Services.PersistentProgress;
using Assets.Code.Services.SaveLoad;


namespace Assets.Code.Infrastructure.States.GameStates
{
    internal sealed class LoadProgressState : GameState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(IStateMachine stateMachine,
            IPersistentProgressService progressService,
            ISaveLoadService saveLoadService)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public override void Enter()
        {
            LoadProgressOrInitNew();
            _stateMachine.Enter<LoadSceneState, string>(
                _progressService.Progress.WorldData.PositionOnLevel.Level);
        }

        public override void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress()
        {
            return new PlayerProgress(SceneNames.GameScene);
        }
    }
}
