using Project.Infrastructure.Services.InputService;

namespace Project.Infrastructure.Services.Factories.UIFactories
{
    public interface IJoystickUIFactory
    {
        public JoystickInputService CreateJoystickUI();
    }
}