using Assets.Code.Infrastructure.AssetManagement;
using Assets.Code.StaticData;
using UnityEngine;


namespace Assets.Code.UI.Services
{
    public sealed class UiFactory
    {
        private readonly IAssetProvider _assets;
        private readonly StaticDataService _staticData;

        private Transform _uiRoot;


        public UiFactory(IAssetProvider assets, StaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        internal void CreateUiRoot()
        {
            _uiRoot = _assets.Instantiate("UIRoot", Vector3.zero).transform;
        }

        internal void CreateShop()
        {
            var config = _staticData.ForWindow(WindowId.Shop);
            var window = Object.Instantiate(config.Prefab, _uiRoot);
            window.transform.localPosition = Vector3.zero;
        }
    }
}
