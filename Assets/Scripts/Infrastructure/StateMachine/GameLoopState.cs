using PerikDiContainer;
using YG;

namespace YGameTemplate.Infrastructure.StateMachine
{
    public class GameLoopState : IPayloadedState<DiContainer>
    {
        private readonly GameStateMachine _gameStateMachine;
        private DiContainer _sceneContainer;

        public GameLoopState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter(DiContainer sceneContainer)
        {
            _sceneContainer = sceneContainer;
        }

        public void Exit()
        {

        }
    }
}