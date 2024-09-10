using EgeBlogSite.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgeBlogSite.CORE.SingletonObject
{
   public class SingletonDB
    {
        private static BlogSiteEntities _instance;
        public static BlogSiteEntities GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BlogSiteEntities();

            }
            return _instance;
        }
    }
}
