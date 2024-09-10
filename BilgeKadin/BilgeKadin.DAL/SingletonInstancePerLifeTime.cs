using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeKadin.DAL
{
    public static class SingletonInstancePerLifeTime
    {
        private static BilgeKadinEntities dbcontext;
        public static BilgeKadinEntities GetContextInstance()
        {
            if (dbcontext == null)
            {
                dbcontext = new BilgeKadinEntities();
            }
            return dbcontext;
        }

    }
}
