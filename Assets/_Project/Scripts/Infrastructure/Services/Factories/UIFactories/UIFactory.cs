using Project.Infrastructure.Root;
using Project.Infrastructure.Services.AssetsManagement;

namespace Project.Infrastructure.Services.Factories.UIFactories
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetsProvider _assetsProvider;
        private readonly UIRoot _uiRoot;

        public UIFactory(UIRoot uiRoot, IAssetsProvider assetsProvider)
        {
            _uiRoot = uiRoot;
            _assetsProvider = assetsProvider;
        }

        public ILoadingScreensUIFactory LoadingScreensUIFactory => new LoadingScreensUIFactory(_uiRoot, _assetsProvider);

        public IJoystickUIFactory JoystickUIFactory => new JoystickUIFactory(_uiRoot, _assetsProvider);
    }
}