using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Server.Data
{
    public class ModelChangesDBConfiguration : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {

        protected override void Seed(DataBaseContext context)
        {
#if DEBUG
            new LearningDataSeeder(context).Seed();
            //new DataBaseContextInitializer().Seed(context);
#endif
            base.Seed(context);
        }

    }
}
