using BilgeKoleji.Core.Services;
using BilgeKoleji.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.BLL.Abstract
{
   public interface IOgretmenService : IServiceBase
    {
        List<OgretmenDTO> getAll();
        OgretmenDTO getOgretmen(int ogretmenId);
        List<OgretmenDTO> getOgretmenName(string ogretmenName);
        OgretmenDTO newOgretmen(OgretmenDTO ogretmen);
        OgretmenDTO updateOgretmen(OgretmenDTO ogretmen);
        bool deleteOgretmen(int OgretmenId);
    }
}
