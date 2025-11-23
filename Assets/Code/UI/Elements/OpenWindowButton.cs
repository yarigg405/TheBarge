using Assets.Code.UI.Services;
using UnityEngine;
using UnityEngine.UI;
using VContainer;


namespace Assets.Code.UI.Elements
{
    public sealed class OpenWindowButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField ] private WindowId _windowId;

        [Inject] private readonly WindowService _windowService;

        private void Awake()
        {
            _button.onClick.AddListener(Open);
        }

        private void Open()
        {
            _windowService.Open(_windowId);
        }
    }
}
