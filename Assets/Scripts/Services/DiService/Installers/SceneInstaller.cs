using PerikDiContainer;
using UnityEngine;

namespace YGameTemplate
{
    public class SceneInstaller: MonoBehaviour
    {
        private DiContainer _sceneContainer;

        public DiContainer GetSceneInstaller(DiContainer projectContainer) 
        { 
            _sceneContainer = new DiContainer(projectContainer);
            RegisterInitConfigs();
            return _sceneContainer;
        }

        private void RegisterInitConfigs()
        {

        }
    }
}