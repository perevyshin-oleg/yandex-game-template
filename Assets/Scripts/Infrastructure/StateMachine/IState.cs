namespace YGameTemplate.Infrastructure
{
    public interface IState: IExitableState
    {
        void Enter();
    }
}