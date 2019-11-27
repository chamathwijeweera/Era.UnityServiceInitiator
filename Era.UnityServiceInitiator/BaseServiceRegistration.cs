using Unity;

namespace Era.UnityServiceInitiator
{
    public class BaseServiceRegistration : IContainerRegistrationModule<IUnityContainer>
    {
        public virtual void Register(IUnityContainer container)
        {
            container.RegisterType<IServiceLocator, CustomUnityServiceLocator>();
        }
    }
}
