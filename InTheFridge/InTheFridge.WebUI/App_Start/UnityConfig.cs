using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using InTheFridge.DAL.Repositories;
using InTheFridge.Model;
using InTheFridge.DAL.Data;
using InTheFridge.Contracts.Repositories;
using Microsoft.AspNet.Identity;
using InTheFridge.WebUI.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using InTheFridge.WebUI.Controllers;
using System.Web;
using Microsoft.Owin.Security;

namespace InTheFridge.WebUI.App_Start
{
    //    /// <summary>
    //    /// Specifies the Unity configuration for the main container.
    //    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        //        /// <summary>
        //        /// Gets the configured Unity container.
        //        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        //        /// <summary>Registers the type mappings with the Unity container.</summary>
        //        /// <param name="container">The unity container to configure.</param>
        //        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        //        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IRepositoryBase<Recipe>, RecipeRepository>();
            container.RegisterType<IRepositoryBase<Ingredient>, IngredientRepository>();
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<UserManager<ApplicationUser>>();
            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            //container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            //container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            //container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            //container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(o => HttpContext.Current.GetOwinContext().Authentication));
            //container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new InjectionConstructor(new ApplicationDbContext()));
        }
    }
}

