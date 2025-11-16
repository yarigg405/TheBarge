using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.States.StatesInfrastructure;
using Assets.Code.Services.Input;


namespace Assets.Code.Infrastructure.States.GameStates
{
    internal sealed class BootstrapState : GameState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IScenesLoader _scenesLoader;

        public BootstrapState(IStateMachine stateMachine, IScenesLoader scenesLoader)
        {
            _stateMachine = stateMachine;
            _scenesLoader = scenesLoader;
        }

        public override void Enter()
        {
            RegisterServices();
            _scenesLoader.LoadScene(SceneNames.InitScene, EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadSceneState, string>(SceneNames.GameScene);
        }

        private static void RegisterServices()
        {
            Game.InputService = new InputService();
        }
    }
}
