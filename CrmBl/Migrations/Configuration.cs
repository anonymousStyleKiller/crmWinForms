
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace CrmBl.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CrmBl.Model.CrmContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}