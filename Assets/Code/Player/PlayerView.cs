using UnityEngine;


namespace Assets.Code.Player
{
    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform[] _engineViews;

        public void SetMoveValue(float value)
        {
            foreach (var view in _engineViews)
            {
                view.localScale = Vector3.one * value;
            }
        }
    }
}