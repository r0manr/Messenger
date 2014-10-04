using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using System.Web.Routing;
using MessangerFirst.Core.Repository;
using MessangerFirst.Core.Security;
using MessangerFirst.Core.Service;
using MessangerFirst.Data;
using MessangerFirst.Service;
using MessangerFirst.WebUI.Controllers;
using Ninject;

namespace MessangerFirst.WebUI.Infrastructure
{
    /// <summary>
    /// IoC-контейнер
    /// </summary>
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            _ninjectKernel.Load(Assembly.GetExecutingAssembly());
            GlobalConfiguration.Configuration.DependencyResolver = new LocalNinjectDependencyResolver(_ninjectKernel);
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)_ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            _ninjectKernel.Bind<IDbContextFactory>().To<DbContextFactory>().InSingletonScope();
            _ninjectKernel.Bind(typeof(ICrudService<>)).To(typeof(CrudService<>));
            _ninjectKernel.Bind<IUserService>().To<UserService>();
            _ninjectKernel.Bind<IMessageService>().To<MessageService>();
            _ninjectKernel.Bind(typeof(IRepo<>)).To(typeof(Repo<>));
            _ninjectKernel.Bind<IFormsAuthentication>().To<FormAuthService>();
            _ninjectKernel.Bind<IHasher>().To<Hasher>();
        }
    }

    public class LocalNinjectDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IKernel _kernel;

        public LocalNinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _kernel.GetAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }
        public void Dispose()
        {

        }
    }
}