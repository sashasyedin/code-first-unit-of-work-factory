using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Quizmaster.Business.Contracts;
using Quizmaster.Business.Services;
using Quizmaster.DataAccess;
using Quizmaster.DataAccess.Contracts;

namespace Quizmaster.Web
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public NinjectControllerFactory()
        {
            this._kernel = new StandardKernel();
            this.AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;

            return (IController)this._kernel.Get(controllerType);
        }

        private void AddBindings()
        {
            // Services:
            this._kernel.Bind<IQuestionService>().To<QuestionService>();

            // Parameters:
            this._kernel.Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>();
            this._kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));

            // Database context:
            this._kernel.Bind<IDbContext>().To<QuizmasterContext>().WithConstructorArgument("connectionString", "QuizmasterConnection");
        }
    }
}
