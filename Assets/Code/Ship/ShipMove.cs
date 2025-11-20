using Assets.Code.Data;
using Assets.Code.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yrr.Utils;


namespace Assets.Code.Ship
{
    public sealed class ShipMove : MonoBehaviour, ISavedProgress, ISavedProgressReader
    {
        [SerializeField] private float _acceleration;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private ShipView _playerView;


        public void UpdateMoving(Vector2 inputVector)
        {
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

        void ISavedProgress.UpdateProgress(PlayerProgress progress)
        {
            progress.WorldData.PositionOnLevel = new(
                SceneManager.GetActiveScene().name,
                new(transform.position));
        }

        void ISavedProgressReader.LoadProgress(PlayerProgress progress)
        {
            if (progress.WorldData.PositionOnLevel == null) return;
            if (!SceneManager.GetActiveScene().name.Equals(progress.WorldData.PositionOnLevel.Level)) return;

            var savedPosition = progress.WorldData.PositionOnLevel.Position;
            transform.position = new Vector3(savedPosition.X, savedPosition.Y, savedPosition.Z);
        }
    }
}