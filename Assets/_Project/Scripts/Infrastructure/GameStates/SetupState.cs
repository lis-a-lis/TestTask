using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Infrastructure.Root;
using Project.Infrastructure.Services.Factories.EntityFactories;
using Project.Infrastructure.Services.InputService;
using Project.Infrastructure.Services.Factories.UIFactories;
using Project.Control;

namespace Project.Infrastructure.GameStates
{
    public class SetupState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly UIRoot _uiRoot;
        private readonly IGameEntitiesFactory _gameEntitiesFactory;
        private readonly IUIFactory _uiFactory;
        private readonly List<Action> _setupActions;
        private IInputService _playerMovementInputService;
        private IInputService _playerCameraInputService;

        public SetupState(GameStateMachine gameStateMachine, CoroutineRunner coroutineRunner,
            UIRoot uiRoot, IGameEntitiesFactory entitiesFactory, IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _coroutineRunner = coroutineRunner;
            _uiRoot = uiRoot;
            _gameEntitiesFactory = entitiesFactory;
            _uiFactory = uiFactory;
        }

        private void SetupInput()
        {
            JoystickInputService joystick = _uiFactory.JoystickUIFactory.CreateJoystickUI();
            _playerCameraInputService = joystick.CameraInput;
            _playerMovementInputService = joystick.MovementInput;
        }

        private void SetupPlayer()
        {
            Player player = _gameEntitiesFactory.CreatePlayer();
            player.GetComponent<PlayerMovement>().Initialize(_playerMovementInputService);
            player.GetComponentInChildren<CameraMovement>().Initialize(_playerCameraInputService);

            PlayerSpawnPoint spawnPoint = UnityEngine.Object.FindFirstObjectByType<PlayerSpawnPoint>();

            player.gameObject.transform.position = spawnPoint.transform.position;
        }

        public void Enter()
        {
            Debug.Log("Setup state process");

            _coroutineRunner.StartCoroutine(Setup());
        }

        public void Exit()
        {
            _uiRoot.HideLoadingScreen();
        }

        private IEnumerator Setup()
        {
            yield return null;
            SetupInput();
            SetupPlayer();
            yield return null;
            _gameStateMachine.Enter<GameplayState>();
        }
    }
}