namespace Dnd.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Route for durandal views, so they can be placed in the default views folder.
            routes.MapRoute(
                name: "App Views",
                url: "App/{viewName}",
                defaults: new { controller = "App", action = "Get" }
            );

            routes.MapRoute(
                name: "App Dir Views",
                url: "App/{directory}/{viewName}",
                defaults: new { controller = "App", action = "GetDir" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
