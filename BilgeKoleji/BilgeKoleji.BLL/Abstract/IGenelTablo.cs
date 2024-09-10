using BilgeKoleji.Core.Services;
using BilgeKoleji.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.BLL.Abstract
{
   public interface IGenelTablo : IServiceBase
    {
        List<GenelTabloDTO> getAll();
        GenelTabloDTO getTablo(int tabloId);
        List<GenelTabloDTO> getTabloName(string tabloName);
        GenelTabloDTO newTablo(GenelTabloDTO tablo);
        GenelTabloDTO updateTablo(GenelTabloDTO tablo);
        bool deleteTablo(int tabloId);
    }
}
