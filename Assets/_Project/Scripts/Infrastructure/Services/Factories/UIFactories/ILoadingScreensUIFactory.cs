using Project.Infrastructure.Root;

namespace Project.Infrastructure.Services.Factories.UIFactories
{
    public interface ILoadingScreensUIFactory
    {
        LoadingScreenView CreateMainLoadingScreen();
    }
}