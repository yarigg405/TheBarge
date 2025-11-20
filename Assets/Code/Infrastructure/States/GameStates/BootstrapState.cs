using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.States.StatesInfrastructure;


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
            EnterLoadLevel();
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadProgressState>();
        }
    }
}
