using Autofac;
using Autofac.Integration.Mvc;
using LearningApp.Controllers;
using LearningApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using LearningApp.Utility;
using System.Web.Routing;
using LearningApp.ApiRepository;
using Autofac.Integration.WebApi;
using LearningApp.Controllers.WebApiController;

namespace LearningApp
{
    public static class AutoFacBuilder
    {
        public static IContainer Configure(RouteCollection routes)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AdminRepository>().As<IAdminRepository>();
            builder.RegisterType<HtmlHelperClass>().As<IHtmlHelpers>();
            builder.RegisterType<ApiAdminRepository>().As<IApiAdminRepository>();
            builder.RegisterType<SQLHelper>().As<ISQLHelper>();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<AdminController>().AsSelf();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            return container;

        }
    }
}