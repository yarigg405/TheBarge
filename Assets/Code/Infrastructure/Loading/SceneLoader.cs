using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine.SceneManagement;


namespace Assets.Code.Infrastructure.Loading
{
    public sealed class SceneLoader : IScenesLoader
    {
        public string CurrentScene { get; private set; }

        public void LoadScene(string name, Action onLoaded = null)
        {
            CurrentScene = name;
            LoadAsync(name, onLoaded).Forget();
        }

        private async UniTaskVoid LoadAsync(string sceneName, Action onLoaded, CancellationToken cancellationToken = default)
        {
            await SceneManager.LoadSceneAsync(sceneName).ToUniTask();
            onLoaded?.Invoke();
        }
    }
}