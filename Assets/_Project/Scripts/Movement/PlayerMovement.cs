using Project.Infrastructure.Services.InputService;
using UnityEngine;

namespace Project.Control
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private IInputService _movementInput;

        private CharacterController _characterController;

        public void Initialize(IInputService input)
        {
            _movementInput = input;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Vector3 direction = Vector3.forward * _movementInput.Vertical + Vector3.right * _movementInput.Horizontal;
            _characterController.Move(_speed * Time.deltaTime * direction);
        }
    }
}