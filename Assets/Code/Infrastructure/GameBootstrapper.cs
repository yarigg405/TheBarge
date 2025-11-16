using Assets.Code.Infrastructure.States.GameStates;
using UnityEngine;


namespace Assets.Code.Infrastructure
{
    public sealed class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game();
            _game.StateMachine.Enter<BootstrapState>();
        }
    }
}