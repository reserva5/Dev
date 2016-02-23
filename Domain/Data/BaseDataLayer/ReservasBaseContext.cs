using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDataLayer
{
    public class ReservasBaseContext<TContext> : DbContext where TContext : DbContext
    {
        private Type _Hack = typeof(SqlProviderServices);

        static ReservasBaseContext()
        {
            Database.SetInitializer<TContext>(null);
        }

        protected ReservasBaseContext() : base("name=ReservasConnectionString")
        {

        }
    }
}
