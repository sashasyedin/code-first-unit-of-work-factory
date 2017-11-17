using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Quizmaster.Business.Contracts;
using Quizmaster.Business.Services;
using Quizmaster.DataAccess;
using Quizmaster.DataAccess.Contracts;

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
            // Services:
            kernel.Bind<IQuestionService>().To<QuestionService>();

            // Parameters:
            kernel.Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));

            // Database context:
            kernel.Bind<IDbContext>().To<QuizmasterContext>().WithConstructorArgument("connectionString", "QuizmasterConnection");
        }
    }
}
