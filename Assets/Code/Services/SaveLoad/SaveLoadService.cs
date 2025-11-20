using Assets.Code.Data;
using Assets.Code.Infrastructure.Factory;
using Assets.Code.Services.PersistentProgress;
using UnityEngine;


namespace Assets.Code.Services.SaveLoad
{
    public sealed class SaveLoadService : ISaveLoadService
    {
        private const string Key = "Progress";

        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;

        public SaveLoadService(IGameFactory gameFactory, IPersistentProgressService progressService)
        {
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        void ISaveLoadService.SaveProgress()
        {
            foreach (var prWr in _gameFactory.ProgressWriters)
            {
                prWr.UpdateProgress(_progressService.Progress);
            }

            PlayerPrefs.SetString(Key, _progressService.Progress.ToJson());
        }

        PlayerProgress ISaveLoadService.LoadProgress()
        {
            return PlayerPrefs.GetString(Key)?
                  .ToDeserealized<PlayerProgress>();
        }
    }
}
