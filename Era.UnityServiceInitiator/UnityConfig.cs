using System;
using System.Configuration;
using Unity;

namespace Era.UnityServiceInitiator
{
    public class UnityConfig
    {
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetUnityContainer()
        {
            return Container.Value;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            string assembly = ConfigurationManager.AppSettings["UnityRegistrationAssemblyType"];

            if (string.IsNullOrWhiteSpace(assembly))
                throw new Exception("Provide fully qualified name of the class which contains the dependency registration");

            var assemblyQualifiedName = Type.GetType(assembly).AssemblyQualifiedName;

            Type UnityRegistrationModule = Type.GetType(assemblyQualifiedName);

            var module = (IContainerRegistrationModule<IUnityContainer>)Activator.CreateInstance(UnityRegistrationModule);

            module.Register(container);
        }
    }
}
