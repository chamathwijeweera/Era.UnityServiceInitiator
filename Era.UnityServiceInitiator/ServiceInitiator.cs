using Unity;

namespace Era.UnityServiceInitiator
{
    public class ServiceInitiator
    {
        private static IUnityContainer _unityContainer = null;
        private static IServiceLocator _serviceLocator = null;

        private static IUnityContainer UnityContainer
        {
            get { return _unityContainer ?? (_unityContainer = UnityConfig.GetUnityContainer()); }
        }

        private static IServiceLocator ServiceLocator
        {
            get { return _serviceLocator ?? (_serviceLocator = UnityContainer.Resolve<IServiceLocator>()); }
        }

        public TService GetService<TService>()
        {
            return ServiceLocator.Get<TService>();
        }
    }
}
