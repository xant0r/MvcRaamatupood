namespace MvcRaamatupood.Migrations
{
    using MvcRaamatupood.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcRaamatupood.Models.RaamatupoodDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcRaamatupood.Models.RaamatupoodDBContext context)
        {
            

        }
    }
}
