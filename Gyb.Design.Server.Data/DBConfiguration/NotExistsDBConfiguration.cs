using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Server.Data
{
    public class NotExistsDBConfiguration : CreateDatabaseIfNotExists<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
#if DEBUG
            new DataBaseContextInitializer().Seed(context);
#endif
            base.Seed(context);
        }

    }
}
