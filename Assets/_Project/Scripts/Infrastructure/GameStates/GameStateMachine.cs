using System;
using System.Collections.Generic;
using Project.Infrastructure.Root;
using Project.Infrastructure.Services;
using Project.Infrastructure.Services.SceneLoading;
using Project.Infrastructure.Services.Factories.UIFactories;
using Project.Infrastructure.Services.Factories.EntityFactories;

namespace Project.Infrastructure.GameStates
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(CoroutineRunner coroutineRunner, UIRoot uiRoot)
        {
            ServicesContainer container = new ServicesContainer();

            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, container, coroutineRunner, uiRoot),

                [typeof(LoadLevelState)] = new LoadLevelState(this, container.Get<ISceneLoader>()),

                [typeof(SetupState)] = new SetupState(this, coroutineRunner, uiRoot,
                    container.Get<IGameEntitiesFactory>(), container.Get<IUIFactory>()),

                [typeof(GameplayState)] = new GameplayState(this),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            ChangeState<TState>().Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            ChangeState<TState>().Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}