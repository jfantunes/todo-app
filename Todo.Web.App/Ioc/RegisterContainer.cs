using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Todo.Web.App.MailService;
using Todo.Web.App.Models.Repository;

namespace Todo.Web.App.Ioc
{
    public static class RegisterContainer
    {
        public static Container RegisterRepository()
        {

            var container = new Container();
            container.Register<ITaskRepository, TaskRepository>();
            container.Verify();
            return container;
        }

    }
}