using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace EtudeV2.Data
{
    public class EtudeV2MigrationConfiguration : DbMigrationsConfiguration<EtudeV2Context>
    {
        public EtudeV2MigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

#if DEBUG
        protected override void Seed(EtudeV2Context context)
        {
            // Seed the DB
            new EtudeV2Seeder(context).Seed();
        }
#endif
    }
}
