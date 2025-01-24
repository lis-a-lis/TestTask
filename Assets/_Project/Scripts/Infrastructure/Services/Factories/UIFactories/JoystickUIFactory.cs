using UnityEngine;
using Project.Infrastructure.Root;
using Project.Infrastructure.Services.AssetsManagement;

namespace Project.Infrastructure.Services.Factories.UIFactories
{
    public class JoystickUIFactory : IJoystickUIFactory
    {
        private const string JoystickInputPrefabPath = "Input";

        private readonly IAssetsProvider _assetsProvider;
        private readonly UIRoot _uIRoot;

        public JoystickUIFactory(UIRoot uiRoot, IAssetsProvider assetsProvider)
        {
            _uIRoot = uiRoot;
            _assetsProvider = assetsProvider;
        }
        public JoystickInputService CreateJoystickUI()
        {
            JoystickInputService prefab = _assetsProvider.LoadPrefab<JoystickInputService>(JoystickInputPrefabPath);
            JoystickInputService input = Object.Instantiate(prefab);
            _uIRoot.AttachUI(input.transform);

            return input;
        }
    }
}