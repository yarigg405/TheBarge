using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Assets.Code.Infrastructure.AssetManagement
{
    public sealed class AssetProvider : IAssetProvider
    {
        private readonly IObjectResolver _objectResolver;

        public AssetProvider(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        GameObject IAssetProvider.Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            var instance = GameObject.Instantiate(prefab, at, Quaternion.identity);
            _objectResolver.InjectGameObject(instance);

            return instance;
        }
    }
}
