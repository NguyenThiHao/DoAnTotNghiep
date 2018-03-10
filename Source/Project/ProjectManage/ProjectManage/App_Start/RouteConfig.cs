using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectManage
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

          //  routes.MapRoute(
          //      name: "Login",
          //      url: "Login/{metatitle}",
          //      defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional },
          //      namespaces: new[] {"ProjectManage.Controllers"}
          //  );

          //  routes.MapRoute(
          //      name: "Project",
          //      url: "Project/{metatitle}",
          //      defaults: new { controller = "Project", action = "CreateProject", id = UrlParameter.Optional },
          //      namespaces: new[] { "ProjectManage.Controllers" }
          //  );

          //  routes.MapRoute(
          //      name: "Phase",
          //      url: "Phase/{metatitle}",
          //      defaults: new { controller = "Phase", action = "CreatePhase", id = UrlParameter.Optional },
          //      namespaces: new[] { "ProjectManage.Controllers" }
          //  );

          //  routes.MapRoute(
          //    name: "Sprint",
          //    url: "Sprint/{metatitle}",
          //    defaults: new { controller = "Sprint", action = "CreateSprint", id = UrlParameter.Optional },
          //    namespaces: new[] { "ProjectManage.Controllers" }
          //);


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional },
                namespaces: new[] { "ProjectManage.Controllers" }
            );
        }
    }
}
