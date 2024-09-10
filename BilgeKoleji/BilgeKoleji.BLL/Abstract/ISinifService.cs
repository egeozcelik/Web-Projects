using BilgeKoleji.Core.Services;
using BilgeKoleji.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.BLL
{
    public interface ISinifService : IServiceBase
    {
        List<SinifDTO> getAll();
        SinifDTO getSinif(int sinifId);
        List<SinifDTO> getSinifName(string sinifName);
        SinifDTO newSinif(SinifDTO sinif);
        SinifDTO updateSinif(SinifDTO sinif);
        bool deleteSinif(int SinifId);
        

    }
}
