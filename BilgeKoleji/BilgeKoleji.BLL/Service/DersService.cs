using BilgeKoleji.BLL.Abstract;
using BilgeKoleji.Core.Data.UnitOfWork;
using BilgeKoleji.DTO;
using BilgeKoleji.Mapping.ConfigProfile;
using BilgeKoleji.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilgeKoleji.BLL.Service
{
    public class DersService : IDersService
    {
        private readonly IUnitOfWork uow;
        public DersService(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public bool deleteDers(int DersId)
        {
            try
            {
                var ders = uow.GetRepository<Ders>().Get(z => z.Id == DersId);
                uow.GetRepository<Ders>().Delete(ders);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<DersDTO> getAll()
        {
            var dersList = uow.GetRepository<Ders>().GetAll();
            return MapperFactory.CurrentMapper.Map<List<DersDTO>>(dersList);
        }

        public DersDTO getDers(int dersId)
        {
            var ders = uow.GetRepository<Ders>().Get(z => z.Id == dersId);
            return MapperFactory.CurrentMapper.Map<DersDTO>(ders);
        }

        public List<DersDTO> getDersName(string dersName)
        {
            var dersList = uow.GetRepository<Ders>().Get(z => z.Adi.Contains(dersName), null).ToList();
            return MapperFactory.CurrentMapper.Map<List<DersDTO>>(dersList);

        }

        public DersDTO newDers(DersDTO ders)
        {
            if (!uow.GetRepository<Ders>().GetAll().Any(z => z.Adi == ders.Adi))
            {
                var eklenen = MapperFactory.CurrentMapper.Map<Ders>(ders);
                uow.GetRepository<Ders>().Add(eklenen);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<DersDTO>(eklenen);
            }
            else
                return null;
        }

        public DersDTO updateDers(DersDTO ders)
        {
            var güncel = uow.GetRepository<Ders>().Get(z => z.Id == ders.Id);
            güncel = MapperFactory.CurrentMapper.Map<Ders>(ders);
            uow.GetRepository<Ders>().Update(güncel);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<DersDTO>(güncel);
        }
    }
}
