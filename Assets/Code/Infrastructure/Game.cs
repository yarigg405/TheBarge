using Assets.Code.Services.Input;


namespace Assets.Code.Infrastructure
{
    public sealed class Game
    {
        public static IInputService InputService;

        public Game()
        {
            InputService = new InputService();
        }
    }
}
