using BilgeKoleji.BLL.Abstract;
using BilgeKoleji.Core.Data.UnitOfWork;
using BilgeKoleji.Core.Services;
using BilgeKoleji.DTO;
using BilgeKoleji.Mapping.ConfigProfile;
using BilgeKoleji.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilgeKoleji.BLL.Service
{
    public class GenelTabloService : IGenelTablo
    {
        private readonly IUnitOfWork uow;
        public GenelTabloService(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public bool deleteTablo(int tabloId)
        {
            try
            {
                var tablo = uow.GetRepository<GenelTablo>().Get(z => z.Id == tabloId);
                uow.GetRepository<GenelTablo>().Delete(tablo);
                uow.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<GenelTabloDTO> getAll()
        {
            var tabloList = uow.GetRepository<GenelTablo>().GetAll();
            return MapperFactory.CurrentMapper.Map<List<GenelTabloDTO>>(tabloList);
        }

        public GenelTabloDTO getTablo(int tabloId)
        {
            var tablo = uow.GetRepository<GenelTablo>().Get(z => z.Id == tabloId);
            return MapperFactory.CurrentMapper.Map<GenelTabloDTO>(tablo);
        }

        public List<GenelTabloDTO> getTabloName(string tabloName)
        {
            throw new NotImplementedException();

        }

        public GenelTabloDTO newTablo(GenelTabloDTO tablo)
        {
            if (!uow.GetRepository<GenelTablo>().GetAll().Any(z => z.Id == tablo.Id))
            {
                var eklenen = MapperFactory.CurrentMapper.Map<GenelTablo>(tablo);
                uow.GetRepository<GenelTablo>().Add(eklenen);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<GenelTabloDTO>(eklenen);
            }
            else
                return null;
        }

        public GenelTabloDTO updateTablo(GenelTabloDTO tablo)
        {
            var güncel = uow.GetRepository<GenelTablo>().Get(z => z.Id == tablo.Id);
            güncel = MapperFactory.CurrentMapper.Map<GenelTablo>(tablo);
            uow.GetRepository<GenelTablo>().Update(güncel);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<GenelTabloDTO>(güncel);

        }
    }
}
