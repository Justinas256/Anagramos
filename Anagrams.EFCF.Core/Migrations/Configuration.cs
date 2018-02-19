namespace Anagrams.EFCF.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Anagrams.EFCF.Core.Context.AnagramCFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Anagrams.EFCF.Core.Context.AnagramCFContext";
        }

        protected override void Seed(Anagrams.EFCF.Core.Context.AnagramCFContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
