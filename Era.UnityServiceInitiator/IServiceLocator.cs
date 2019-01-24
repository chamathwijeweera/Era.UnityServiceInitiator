
namespace Era.UnityServiceInitiator
{
    public interface IServiceLocator
    {
        T Get<T>();
    }

    public interface IContainerRegistrationModule<T>
    {
        void Register(T container);
    }
}
