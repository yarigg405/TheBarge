using Assets.Code.Infrastructure.Loading;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;


namespace Assets.Code.Tempo
{
    public sealed class InitSceneLoader : MonoBehaviour
    {
        [Inject] private readonly IScenesLoader _scenesLoader;

        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            if (_scenesLoader == null)
                SceneManager.LoadScene(SceneNames.InitScene);
        }
    }
}
