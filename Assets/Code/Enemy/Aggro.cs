using UnityEngine;


namespace Assets.Code.Enemy
{
    public sealed class Aggro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyFollow _follow;


        private void Start()
        {
            _triggerObserver.TriggerEntered += TriggerEnter;
            _triggerObserver.TriggerExited += TriggerExit;

            _follow.enabled = false;
        }

        private void OnDestroy()
        {
            _triggerObserver.TriggerEntered -= TriggerEnter;
            _triggerObserver.TriggerExited -= TriggerExit;
        }

        private void TriggerEnter(Collider collider)
        {
            _follow.SetFollowTarget(collider.transform);
            _follow.enabled = true;
        }

        private void TriggerExit(Collider collider)
        {
            _follow.enabled = false;
        }
    }
}
