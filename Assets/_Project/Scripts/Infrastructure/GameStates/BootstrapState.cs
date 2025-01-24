using UnityEngine;
using Project.Infrastructure.Root;
using Project.Infrastructure.Services;
using Project.Infrastructure.Services.SceneLoading;
using Project.Infrastructure.Services.AssetsManagement;
using Project.Infrastructure.Services.Factories.UIFactories;
using Project.Infrastructure.Services.Factories.EntityFactories;

namespace Project.Infrastructure.GameStates
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly ServicesContainer _services;
        private readonly UIRoot _uiRoot;

        public BootstrapState(GameStateMachine gameStateMachine, ServicesContainer servicesContainer,
            CoroutineRunner coroutineRunner, UIRoot uiRoot)
        {
            _gameStateMachine = gameStateMachine;
            _coroutineRunner = coroutineRunner;
            _services = servicesContainer;
            _uiRoot = uiRoot;

            RegisterServices();

            Debug.Log("Bootstrap state process");
        }

        public void Enter()
        {
            _gameStateMachine.Enter<LoadLevelState>();
        }

        public void Exit()
        {
            
        }

        private void RegisterServices()
        {
            _services.Register<ISceneLoader>(new SceneLoader(_coroutineRunner));
            _services.Register<IAssetsProvider>(new AssetsProvider());
            _services.Register<IGameEntitiesFactory>(new GameEntitiesFactory(_services.Get<IAssetsProvider>()));
            _services.Register<IUIFactory>(new UIFactory(_uiRoot, _services.Get<IAssetsProvider>()));
        }
    }
}