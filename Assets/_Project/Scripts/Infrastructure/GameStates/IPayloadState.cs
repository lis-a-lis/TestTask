namespace Project.Infrastructure.GameStates
{
    public interface IPayloadState<TPayload> : IExitableState
    {
        public void Enter(TPayload payload);
    }
}