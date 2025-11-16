using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Services.Input;


namespace Assets.Code.Infrastructure
{
    public sealed class Game
    {
        public static IInputService InputService;

        public IStateMachine StateMachine;

        public Game()
        {
          //  _stateMachine = new GameStateMachine();
        }
    }
}
