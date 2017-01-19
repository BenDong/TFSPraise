using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using TFSPraise.Abstract;
using TFSPraise.Concrete;
using TFSPraise.Entities;
using System.Data.Entity;

namespace TFSPraise.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.Get(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<RepositoryBase<Blog>>().To<BlogRepository>();
            kernel.Bind<RepositoryBase<Like>>().To<LikeRepository>();
            kernel.Bind<RepositoryBase<UserProfile>>().To<UserRepository>();
            kernel.Bind<RepositoryBase<Receiver>>().To<ReceiverRepository>();
        }
    }
}