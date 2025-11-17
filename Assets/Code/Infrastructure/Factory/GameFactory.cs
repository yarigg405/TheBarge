using Assets.Code.Infrastructure.AssetManagement;
using UnityEngine;
using VContainer;


namespace Assets.Code.Infrastructure.Factory
{
    public sealed class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assets)
        {
            _assetProvider = assets;
        }

        public GameObject CreatePlayer(GameObject at)
        {
            return _assetProvider.Instantiate(AssetPaths.PlayerPrefabPath, at.transform.position);
        }

        public GameObject CreateHud()
        {
            return _assetProvider.Instantiate(AssetPaths.HudPrefabPath, Vector3.zero);
        }
    }
}
