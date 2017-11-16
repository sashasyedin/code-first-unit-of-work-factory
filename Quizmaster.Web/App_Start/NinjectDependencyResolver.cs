using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Quizmaster.Business.Contracts;
using Quizmaster.Business.Services;
using Ninject;
using Quizmaster.DataAccess.Contracts;
using Quizmaster.DataAccess;

namespace Quizmaster.Web
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IQuestionService>().To<QuestionService>();
            kernel.Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>();
            kernel.Bind<IDbContext>().To<QuizmasterContext>().WithConstructorArgument("connectionString", "QuizmasterConnection");
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
        }
    }
}
