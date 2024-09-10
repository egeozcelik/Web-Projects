using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.Mapping.ConfigProfile
{
    public class MapperConfig
    {
        public static void RegisterMappers()
        {
            MapperFactory.RegisterMappers();
        }
    }
}
