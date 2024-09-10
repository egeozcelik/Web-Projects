using BilgeKoleji.Core.Services;
using BilgeKoleji.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.BLL.Abstract
{
   public interface IDersService : IServiceBase
    {
        List<DersDTO> getAll();
        DersDTO getDers(int dersId);
        List<DersDTO> getDersName(string dersName);
        DersDTO newDers(DersDTO ders);
        DersDTO updateDers(DersDTO ders);
        bool deleteDers(int DersId);
    }
}
