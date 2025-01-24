namespace Project.Infrastructure.Services.Factories.EntityFactories
{
    public interface IGameEntitiesFactory
    {
        public Player Player { get; }
        public Player CreatePlayer();
    }
}