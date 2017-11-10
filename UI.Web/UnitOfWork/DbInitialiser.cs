using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using UI.Web.Migrations;

namespace UI.Web.UnitOfWork
{
    public class SchemeTrackDbInitialiser : CreateAndMigrateDatabaseInitializer<SampleContext, Configuration>
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="SchemeTrackDbInitialiser"/>
        /// </summary>
        public SchemeTrackDbInitialiser(Configuration migrationConfiguration)
            : base(migrationConfiguration)
        {

        }

        #endregion

    }

    public class CreateAndMigrateDatabaseInitializer<TContext, TConfiguration>
     : CreateDatabaseIfNotExists<TContext>, IDatabaseInitializer<TContext>
        where TContext : DbContext
        where TConfiguration : DbMigrationsConfiguration<TContext>
    {
        private readonly DbMigrationsConfiguration _configuration;

        #region Constructors

        public CreateAndMigrateDatabaseInitializer(TConfiguration dbMigrationConfiguration)
        {
            _configuration = dbMigrationConfiguration;
        }

        #endregion

        void IDatabaseInitializer<TContext>.InitializeDatabase(TContext context)
        {
            var exists = context.Database.Exists();
            var doSeed = !exists;

            var migrator = new DbMigrator(_configuration);

            if (migrator.GetPendingMigrations().Any())
            {
                migrator.Update();
            }
            base.InitializeDatabase(context);
            if (doSeed)
            {
                Seed(context);
                context.SaveChanges();
            }
            this.AfterInitialisation(context);
        }

        protected virtual void AfterInitialisation(TContext context)
        {

        }
        protected override void Seed(TContext context)
        {
        }
    }
}
