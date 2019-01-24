# Era.UnityServiceInitiator

[Unity](https://www.nuget.org/packages/Unity/) is a popular library in .net which allows .net applications to implement IOC using unity.
This [Unity](https://www.nuget.org/packages/Unity/) preconfigured library helps to simplify and save time on development where a developer has to go through when configuring Unity IOC


## How to install?

```
Install-Package Era.UnityServiceInitiator -Version 1.0.0
```

## How to use it in your project?

* Install the package using Nuget package manager or Package Manager Console.
* Add the application key to the app.config or web.config to add assembly type where the service registration is done. This should be complies the following format and example is given below.
```
    Type registration format - Fully qualified namespace to class, Assembly name

    <add key="UnityRegistrationAssemblyType" value="General.Test.ServiceRegistration, General.Test" />
``` 
* Add **base.Register(container);** code line to your service registration class **Register** method as shown in below code snippet, and inherite the service registration class using **BaseServiceRegistration** class which lives in **Era.UnityServiceInitiator** namespace.
```     
using Era.UnityServiceInitiator;

namespace Test
{
    public class ServiceRegistration : BaseServiceRegistration
    {
        public override void Register(IUnityContainer container)
        {
            base.Register(container);
            // your customer service registatrion goes here
            container.RegisterType<IService, Service>();
        }
    }
}
```
* Finally create a new instance of **ServiceInitiator** class which lives in **Era.UnityServiceInitiator** namespace and use **GetService** generic method followed with your service class that you want use as shown in below code snippet.
```   
using Era.UnityServiceInitiator;

namespace Test
{
    public class SampleClass
    {
        private IService _service;
        
        public SampleClass()
        {
            _service = new ServiceInitiator().GetService<IService>();
        }
    }
 }
```

## Built With

* [Unity](https://www.nuget.org/packages/Unity/) - Unity Container
* [System.Configuration.ConfigurationManager](https://www.nuget.org/packages/System.Configuration.ConfigurationManager/) - System.Configuration.ConfigurationManager


## Authors

* [ChamathWijeweera](https://github.com/chamathwijeweera)


## License

This project is licensed under the MIT License

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration

