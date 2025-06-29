using PerikDiContainer;
using UnityEngine;
using YGameTemplate.Infrastructure;
using YGameTemplate.Infrastructure.StateMachine;

namespace YGameTemplate
{
    public class Bootstraper : MonoBehaviour, ICoroutineRunner
    {
        private GameStateMachine _gameStateMachine;
        private DiContainer _projectDiContainer;

        public void Awake()
        {
            DontDestroyOnLoad(this);
            _projectDiContainer = new DiContainer();
            RegisterCoroutineRunner();
            _gameStateMachine = new(_projectDiContainer);
            _gameStateMachine.Enter<BootstrapState>();
            
        }

        private void RegisterCoroutineRunner()
        {
            _projectDiContainer.RegisterInstance<ICoroutineRunner>(this);
        }
    }
}