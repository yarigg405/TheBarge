using UnityEngine;


namespace Assets.Code.Services.Input
{
    public sealed class InputService : IInputService
    {
        private const string _horizontalAxis = "Horizontal";
        private const string _verticalAxis = "Vertical";
        private const string _buttonOneName = "ButtonA";

        Vector2 IInputService.Axis
        {
            get
            {
                return new Vector2(
                    SimpleInput.GetAxis(_horizontalAxis),
                    SimpleInput.GetAxis(_verticalAxis));
            }
        }

        bool IInputService.IsButtonOneUp()
        {
            return SimpleInput.GetButtonUp(_buttonOneName);
        }
    }
}