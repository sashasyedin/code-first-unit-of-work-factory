using CuttingEdge.Conditions;
using Quizmaster.ApplicationModel.Controllers;
using Quizmaster.Business.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace Quizmaster.ApplicationModel
{
    public class QuizmasterControllerFactory : DefaultControllerFactory
    {
        private readonly IDictionary<string, Func<RequestContext, IController>> _controllerMap;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuizmasterControllerFactory"/> class.
        /// </summary>
        /// <param name="questionService">The question service.</param>
        public QuizmasterControllerFactory(IQuestionService questionService)
        {
            Condition.Requires(questionService, nameof(questionService)).IsNotNull();

            this._controllerMap = new Dictionary<string, Func<RequestContext, IController>>
            {
                ["Home"] = context => new HomeController(),
                ["Question"] = context => new QuestionController(questionService),
            };
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (this._controllerMap.ContainsKey(controllerName) == false)
                return null;

            return this._controllerMap[controllerName](requestContext);
        }
    }
}
