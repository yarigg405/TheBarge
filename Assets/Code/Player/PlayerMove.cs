using Assets.Code.Services.Input;
using UnityEngine;
using VContainer;
using Yrr.Utils;


namespace Assets.Code.Player
{
    public sealed class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float _acceleration;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private PlayerView _playerView;

        [Inject] private readonly IInputService _input;


        private void Update()
        {
            var inputVector = _input.Axis;

            HandleView(inputVector);

            if (inputVector.sqrMagnitude > Mathf.Epsilon)
            {
                HandleRotation(inputVector);
                HandleMovement(inputVector);
            }
        }

        private void HandleMovement(Vector2 inputVector)
        {
            var deltaMove = (inputVector * Time.deltaTime * _acceleration).ToVector3();
            _rigidbody.linearVelocity += deltaMove;
        }

        private void HandleRotation(Vector2 inputVector)
        {
            var current = transform.rotation.eulerAngles.y;
            var target = Extensions.GetAngleDirectionY(inputVector);
            var delta = Mathf.DeltaAngle(current, target);

            var maxRotationSpeed = _rotationSpeed * Time.deltaTime;
            var effectiveRotationSpeed = maxRotationSpeed;

            var newAngle = Extensions.MoveTowardsAngle(current, target, effectiveRotationSpeed);
            transform.rotation = Quaternion.Euler(0, newAngle, 0);
        }

        private void HandleView(Vector2 inputVector)
        {
            _playerView.SetMoveValue(inputVector.SqrMagnitude());
        }
    }
}