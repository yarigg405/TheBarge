using Assets.Code.Services.SaveLoad;
using UnityEngine;
using VContainer;


namespace Assets.Code.Logic
{
    public sealed class SaveTrigger : MonoBehaviour
    {
        [Inject] private readonly ISaveLoadService _saveLoadService;

        private void OnTriggerEnter(Collider other)
        {
            _saveLoadService.SaveProgress();
            gameObject.SetActive(false);
        }
    }
}
