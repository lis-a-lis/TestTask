using System;

namespace Project.Infrastructure.Services.SceneLoading
{
    public interface ISceneLoader
    {
        public void Load(string sceneName, Action onLoaded = null);
        public void LoadWithActivationCondition(string sceneName,
            Func<bool> sceneActivationCondition, Action onLoaded = null, Action<float> onProgressChanged = null);
    }
}