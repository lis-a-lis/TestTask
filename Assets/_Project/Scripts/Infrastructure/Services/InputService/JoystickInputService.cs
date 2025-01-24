using UnityEngine;
using Project.Infrastructure.Services.InputService;

namespace Project.Infrastructure.Services.Factories.UIFactories
{
    public class JoystickInputService : MonoBehaviour
    {
        [SerializeField] private VariableJoystick _movementJoystick;
        [SerializeField] private VariableJoystick _cameraJoystick;
        public IInputService MovementInput => _movementJoystick;
        public IInputService CameraInput => _cameraJoystick;
    }
}