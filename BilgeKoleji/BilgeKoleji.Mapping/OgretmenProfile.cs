using AutoMapper;
using BilgeKoleji.DTO;
using BilgeKoleji.Mapping.ConfigProfile;
using BilgeKoleji.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.Mapping
{
    public class OgretmenProfile: ProfileBase
    {
        public OgretmenProfile()
        {
            CreateMap<Ogretmen, OgretmenDTO>().ReverseMap();
        }
    }
}
