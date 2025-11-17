using Assets.Code.Infrastructure.States.GameStates;
using Assets.Code.Infrastructure.States.StateMachine;
using VContainer.Unity;


namespace Assets.Code.Infrastructure.EntryPoints
{
    public sealed class BootstrapEntryPoint : IStartable
    {
        private readonly IStateMachine _stateMachine;

        public BootstrapEntryPoint(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        void IStartable.Start()
        {
            _stateMachine.Enter<BootstrapState>();
        }
    }
}