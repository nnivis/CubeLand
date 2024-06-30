using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        public SceneLoader(ICoroutineRunner coroutineRunner) =>
        _coroutineRunner = coroutineRunner;

        public void Load(string name, Action onLoaded = null) =>
        _coroutineRunner.StartCoroutine(LoadSceneMode(name, onLoaded));

        private IEnumerator LoadSceneMode(string nextScene, Action onLoaded)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while(!waitNextScene.isDone)
            yield return null;

            onLoaded?.Invoke();
        }
    }
}
