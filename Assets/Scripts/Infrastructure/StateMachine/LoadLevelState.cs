using YGameTemplate.Infrastructure.Factories;
using YGameTemplate.Services;
using YGameTemplate.Services.SceneLoader;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using PerikDiContainer;
using YGameTemplate.UI;
using YGameTemplate;
using YGameTemplate.Infrastructure.AssetProviders;
using Cysharp.Threading.Tasks;
using YGameTemplate.Infrastructure.Factory;

namespace YGameTemplate.Infrastructure.StateMachine
{
    public class LoadLevelState : IPayloadedState<SceneName>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly DiContainer _projectContainer;
        private DiContainer _sceneContainer;
        private SceneLoader _sceneLoader;
        private LoadingCurtain _curtain;

        public LoadLevelState(GameStateMachine gameStateMachine, DiContainer projectContainer)
        {
            _gameStateMachine = gameStateMachine;
            _projectContainer = projectContainer;
        }

        public void Enter(SceneName sceneName)
        {
            YG.YandexGame.FullscreenShow();
            _sceneLoader = _projectContainer.Resolve<SceneLoader>();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        private async void OnLoaded()
        {
            _sceneContainer = GetSceneContainer();
            await InstantiateHUDAsync();

            _gameStateMachine.Enter<GameLoopState, DiContainer>(_sceneContainer);
        }

        public void Exit()
        {
            _curtain.HideCurtain();
        }

        private async UniTask ShowCurtain()
        {
            IAssetProvider assetProvider = _projectContainer.Resolve<IAssetProvider>();
            Factory<LoadingCurtain> factory = new Factory<LoadingCurtain>(assetProvider, BundlePath.Curtain);
            _curtain = await factory.Create();
            _curtain.ShowCurtain();
        }

        private DiContainer GetSceneContainer()
        {
            GameObject gameObject = GameObject.FindGameObjectsWithTag("SceneInstaller").First();
            gameObject.TryGetComponent(out SceneInstaller sceneInstaller);
            return sceneInstaller.GetSceneInstaller(_projectContainer);
        }

        private async UniTask InstantiateHUDAsync()
        {
            IHUDSpawner hudSpawner = new HUDSpawner(_sceneContainer.Resolve<IAssetProvider>());
            HUDRoot hud = await hudSpawner.SpawnHUD();
            HUDController hudController = new(hud, _sceneContainer, _gameStateMachine);
            _sceneContainer.RegisterInstance(hudController);
        }

        private void RegisterLevelData()
        {

        }
    }
}