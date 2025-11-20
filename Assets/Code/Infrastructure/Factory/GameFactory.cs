using Assets.Code.Infrastructure.AssetManagement;
using Assets.Code.Services.PersistentProgress;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Code.Infrastructure.Factory
{
    public sealed class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public List<ISavedProgressReader> ProgressReaders { get; } = new();
        public List<ISavedProgress> ProgressWriters { get; } = new();

        public GameFactory(IAssetProvider assets)
        {
            _assetProvider = assets;
        }

        public GameObject CreatePlayer(GameObject at)
        {
            var gameOblect = _assetProvider.Instantiate(AssetPaths.PlayerPrefabPath, at.transform.position);
            RegisterProgressWatchers(gameOblect);

            return gameOblect;
        }

        private void RegisterProgressWatchers(GameObject gameOblect)
        {
            foreach (var progressReader in gameOblect.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
            {
                ProgressWriters.Add(progressWriter);
            }
            ProgressReaders.Add(progressReader);
        }

        public GameObject CreateHud()
        {
            var gameObject = _assetProvider.Instantiate(AssetPaths.HudPrefabPath, Vector3.zero);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }
    }
}
