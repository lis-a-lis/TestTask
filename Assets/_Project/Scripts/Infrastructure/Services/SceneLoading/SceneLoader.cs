using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Project.Infrastructure.Root;

namespace Project.Infrastructure.Services.SceneLoading
{
    public class SceneLoader : ISceneLoader
    {
        private readonly CoroutineRunner _coroutineRunner;

        public SceneLoader(CoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action onLoaded = null)
        {
            Debug.Log($"Loading scene {sceneName} started...");

            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
        }

        public void LoadWithActivationCondition(string sceneName, Func<bool> sceneActivationCondition,
                                                Action onLoaded = null, Action<float> onProgressChanged = null)
        {
            Debug.Log($"Loading scene with activation condition {sceneName} started...");

            _coroutineRunner.StartCoroutine(
                LoadSceneWithActivationCondition(sceneName, sceneActivationCondition, onLoaded, onProgressChanged));
        }

        private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onLoaded?.Invoke();
                yield break;
            }

            yield return new WaitForSeconds(2f);

            AsyncOperation waitSceneAsync = SceneManager.LoadSceneAsync(sceneName);

            while (!waitSceneAsync.isDone)
                yield return null;

            onLoaded?.Invoke();
        }

        private float ClampProgress(float progress) =>
            Mathf.Clamp01(progress / .9f);


        private IEnumerator LoadSceneWithActivationCondition(string sceneName, Func<bool> sceneActivationCondition,
                                                Action onLoaded = null, Action<float> onProgressChanged = null)
        {
            yield return null;

            AsyncOperation asyncSceneLoadingOperation = SceneManager.LoadSceneAsync(sceneName);
            asyncSceneLoadingOperation.allowSceneActivation = false;

            while (!asyncSceneLoadingOperation.isDone)
            {
                onProgressChanged?.Invoke(ClampProgress(asyncSceneLoadingOperation.progress));

                Debug.Log($"Scene {sceneName} loading progress: {ClampProgress(asyncSceneLoadingOperation.progress)}");

                if (asyncSceneLoadingOperation.progress >= 0.9f)
                {
                    if (sceneActivationCondition())
                        asyncSceneLoadingOperation.allowSceneActivation = true;
                }

                yield return null;
            }

            onLoaded?.Invoke();

            yield break;
        }
    }
}