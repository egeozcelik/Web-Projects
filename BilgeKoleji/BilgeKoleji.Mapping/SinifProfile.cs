using BilgeKoleji.DTO;
using BilgeKoleji.Mapping.ConfigProfile;
using BilgeKoleji.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.Mapping
{
    public class SinifProfile : ProfileBase
    {
        public SinifProfile()
        {
            CreateMap<Sinif, SinifDTO>().ReverseMap();
        }
    }
}
