using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UI.Web.UnitOfWork;

namespace UI.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var migrationConfig = new Migrations.Configuration();
            var dbInitialiser = new SchemeTrackDbInitialiser(migrationConfig);
            Database.SetInitializer(dbInitialiser);
            using (var context = new UnitOfWork.SampleContext())
            {
                context.Database.Initialize(false);
            }

        }
    }
}
