using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using Model;
using UI.Web.Models;

namespace UI.Web.UnitOfWork
{
    public class SampleContext : DbContext
    {
        public SampleContext() : base("DefaultConnection")
        {
            ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized += ObjectContextOnObjectMaterialized;

        }

        private void ObjectContextOnObjectMaterialized(object sender, ObjectMaterializedEventArgs args)
        {
            var materialisationTracker = args.Entity as IEntityWithMaterialisation;
            materialisationTracker?.OnMaterlialisation();

        }

        public DbSet<Person> Person { get; set; }
    }
}