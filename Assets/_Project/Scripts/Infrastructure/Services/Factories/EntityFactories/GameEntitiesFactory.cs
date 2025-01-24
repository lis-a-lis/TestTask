using UnityEngine;
using Project.Infrastructure.Services.AssetsManagement;

namespace Project.Infrastructure.Services.Factories.EntityFactories
{
    public class GameEntitiesFactory : IGameEntitiesFactory
    {
        private const string PlayerPrefabPath = "Player";

        private readonly IAssetsProvider _assetsProvider;

        private Player _player;

        public GameEntitiesFactory(IAssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }

        public Player Player => _player;

        public Player CreatePlayer()
        {
            Player prefab = _assetsProvider.LoadPrefab<Player>(PlayerPrefabPath);
            Player player = Object.Instantiate(prefab);
            _player = player;

            return player;
        }
    }
}