namespace Project.Infrastructure.Services
{
    public interface IServicesContainer
    {
        public TService Get<TService>();
    }
}