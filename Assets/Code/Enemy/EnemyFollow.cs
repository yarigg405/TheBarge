using Assets.Code.Ship;
using UnityEngine;
using Yrr.Utils;


namespace Assets.Code.Enemy
{
    public sealed class EnemyFollow : MonoBehaviour
    {
        [SerializeField] private ShipMove _shipMove;

        private Transform _followTarget;

        private void Update()
        {
            if (!_followTarget) return;

            var input = _followTarget.position - transform.position;
            _shipMove.UpdateMoving(input.normalized.ToVector2XZ());
        }

        public void SetFollowTarget(Transform followTarget)
        {
            _followTarget = followTarget;
        }
    }
}
