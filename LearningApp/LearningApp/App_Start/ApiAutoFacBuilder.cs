using Autofac;
using Autofac.Integration.WebApi;
using LearningApp.ApiRepository;
using LearningApp.Controllers.WebApiController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace LearningApp
{
    public static class ApiAutoFacBuilder
    {
        public static IContainer Configure(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ApiAdminRepository>().As<IApiAdminRepository>();
            builder.RegisterType<SQLHelper>().As<ISQLHelper>();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ApiAdminController>().AsSelf();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;

        }
    }
}