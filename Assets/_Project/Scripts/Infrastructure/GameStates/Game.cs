using Project.Infrastructure.Root;

namespace Project.Infrastructure.GameStates
{
    public class Game
    {
        private GameStateMachine _stateMachine;

        public Game(CoroutineRunner coroutineRunner, UIRoot uiRoot)
        {
            _stateMachine = new GameStateMachine(coroutineRunner, uiRoot);

            _stateMachine.Enter<BootstrapState>();
        }
    }
}