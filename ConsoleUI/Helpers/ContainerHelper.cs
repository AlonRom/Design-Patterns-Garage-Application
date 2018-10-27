using GarageLogic.Services;
using Unity;
using Unity.Lifetime;

namespace ConsoleUI.Helpers
{
    public class ContainerHelper
    {
        private static IUnityContainer s_Container;
        static ContainerHelper()
        {
            s_Container = new UnityContainer();
            s_Container.RegisterType<IGarageService, GarageService>(new ContainerControlledLifetimeManager());
        }

        public static IUnityContainer Container => s_Container;
    }
}
