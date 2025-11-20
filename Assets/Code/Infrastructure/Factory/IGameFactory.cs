using Assets.Code.Services.PersistentProgress;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Code.Infrastructure.Factory
{
    public interface IGameFactory
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }

        void Cleanup();
        GameObject CreateHud();
        GameObject CreatePlayer(GameObject at);
    }
}