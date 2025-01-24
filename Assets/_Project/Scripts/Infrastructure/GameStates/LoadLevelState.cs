using UnityEngine;
using Project.Infrastructure.Services.SceneLoading;

namespace Project.Infrastructure.GameStates
{
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            Debug.Log("Load level process");

            _sceneLoader.Load(Scenes.GAME, () => _gameStateMachine.Enter<SetupState>());
        }

        public void Exit()
        {
            
        }
    }
}