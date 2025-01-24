using UnityEngine;
using Project.Infrastructure.Root;
using Project.Infrastructure.Services.AssetsManagement;

namespace Project.Infrastructure.Services.Factories.UIFactories
{
    public class LoadingScreensUIFactory : ILoadingScreensUIFactory
    {
        private const string LoadingScreenUIPrefabPath = "LoadingScreen";

        private readonly IAssetsProvider _assetsProvider;
        private readonly UIRoot _uIRoot;

        public LoadingScreensUIFactory(UIRoot uiRoot, IAssetsProvider assetsProvider)
        {
            _uIRoot = uiRoot;
            _assetsProvider = assetsProvider;
        }

        public LoadingScreenView CreateMainLoadingScreen()
        {
            LoadingScreenView prefab = _assetsProvider.LoadPrefab<LoadingScreenView>(LoadingScreenUIPrefabPath);
            LoadingScreenView loadingScreen = Object.Instantiate(prefab);
            _uIRoot.AttachUI(loadingScreen.transform);
            loadingScreen.HideLoadingScreen();

            return loadingScreen;
        }
    }
}