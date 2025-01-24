using Project.Infrastructure.Services.InputService;
using UnityEngine;

namespace Project.Control
{
    [RequireComponent(typeof(Camera))]
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float _sensitivity = 2;
        [SerializeField] private Vector2 _rotationAngleLimits = new Vector2(-60, 60);
        private IInputService _cameraInput;

        private float _horizontalRotation;

        public void Initialize(IInputService input)
        {
            _cameraInput = input;
            Debug.Log("Init camera " + _cameraInput.ToString());
        }

        private void Update()
        {
            transform.parent.Rotate(_sensitivity * _cameraInput.Horizontal * Vector3.up);
            _horizontalRotation -= _cameraInput.Vertical * _sensitivity;
            _horizontalRotation = Mathf.Clamp(_horizontalRotation, _rotationAngleLimits.x, _rotationAngleLimits.y);
            transform.localRotation = Quaternion.Euler(_horizontalRotation, 0, 0);
        }
    }
}