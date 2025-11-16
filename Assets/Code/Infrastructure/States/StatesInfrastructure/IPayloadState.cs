namespace Assets.Code.Infrastructure.States.StatesInfrastructure
{
    public interface IPayloadState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}
