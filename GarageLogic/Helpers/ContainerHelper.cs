using GarageLogic.Interfaces;
using Unity;
using Unity.Lifetime;

namespace GarageLogic.Helpers
{
    public static class ContainerHelper
    {
        static ContainerHelper()
        {
            Container = new UnityContainer();
            Container.RegisterType<IGarageManager, GarageManager>(new ContainerControlledLifetimeManager());
        }

        public static IUnityContainer Container { get; }
    }
}
