using System;

using Unity;
using Unity.Injection;

using VerFarm.Kernel.BL.Implemantation;
using VerFarm.Kernel.BL.Service;
using VerFarm.Kernel.Data.Context;
using VerFarm.Kernel.Model.DTO;

namespace VegFarm
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterInstance(EmployeeMapperConfig.CreateMapper());
            container.RegisterType<EFDbContext>(new InjectionConstructor(new EmployeeContext()));
            container.RegisterType<IDbContext, EFDbContext>();
            container.RegisterType<IService<EmployeeDTO>, EmployeeService>();
        }
    }
}