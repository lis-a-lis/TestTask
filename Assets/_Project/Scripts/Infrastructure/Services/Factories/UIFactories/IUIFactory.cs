namespace Project.Infrastructure.Services.Factories.UIFactories
{
    public interface IUIFactory
    {
        public ILoadingScreensUIFactory LoadingScreensUIFactory { get; }
        public IJoystickUIFactory JoystickUIFactory { get; }
    }
}