using Assets.Code.Services.Input;
using Assets.Code.Ship;
using UnityEngine;
using VContainer;


namespace Assets.Code.Player
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private ShipMove _shipMove;

        [Inject] private readonly IInputService _input;


        private void Update()
        {
            var inputVector = _input.Axis;

            _shipMove.UpdateMoving(inputVector);
        }
    }
}