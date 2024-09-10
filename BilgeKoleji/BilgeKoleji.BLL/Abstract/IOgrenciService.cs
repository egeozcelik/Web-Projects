using BilgeKoleji.Core.Services;
using BilgeKoleji.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.BLL.Abstract
{
   public interface IOgrenciService : IServiceBase
    {
        List<OgrenciDTO> getAll();
        OgrenciDTO getOgrenci(int ogrenciId);
        List<OgrenciDTO> getOgrenciName(string ogrenciName);
        OgrenciDTO newOgrenci(OgrenciDTO ogrenci);
        OgrenciDTO updateOgrenci(OgrenciDTO ogrenci);
        bool deleteOgrenci(int OgrenciId);
    }
}



