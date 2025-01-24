using UnityEngine;

namespace Project.Infrastructure.GameStates
{
    public class GameplayState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public GameplayState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            Debug.Log("Gameplay state process");
        }

        public void Exit()
        {

        }
    }
}