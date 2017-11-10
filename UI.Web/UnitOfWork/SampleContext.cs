using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using Model;

namespace UI.Web.UnitOfWork
{
    public class SampleContext : DbContext
    {
        public SampleContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<Person> Person { get; set; }
    }
}