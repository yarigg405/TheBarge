using UnityEngine;


namespace Assets.Code.Services.Input
{
    public interface IInputService
    {
        Vector2 Axis { get; }
        bool IsButtonOneUp();
    }
}
