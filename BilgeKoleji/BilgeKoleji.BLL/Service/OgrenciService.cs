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
    public class OgrenciService : IOgrenciService
    {
        private readonly IUnitOfWork uow;
        public OgrenciService(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public bool deleteOgrenci(int OgrenciId)
        {
            try
            {
                var ogrenci = uow.GetRepository<Ogrenci>().Get(z => z.Id == OgrenciId);
                uow.GetRepository<Ogrenci>().Delete(ogrenci);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<OgrenciDTO> getAll()
        {
            var ogrenciList = uow.GetRepository<Ogrenci>().GetAll();
            return MapperFactory.CurrentMapper.Map<List<OgrenciDTO>>(ogrenciList);
        }

        public OgrenciDTO getOgrenci(int ogrenciId)
        {
            var ogrenci = uow.GetRepository<Ogrenci>().Get(z => z.Id == ogrenciId);
            return MapperFactory.CurrentMapper.Map<OgrenciDTO>(ogrenci);
        }

        public List<OgrenciDTO> getOgrenciName(string ogrenciName)
        {
            var ogrenciList = uow.GetRepository<Ogrenci>().Get(z => z.Adi.Contains(ogrenciName),null).ToList();
            return MapperFactory.CurrentMapper.Map<List<OgrenciDTO>>(ogrenciList);
        }

        public OgrenciDTO newOgrenci(OgrenciDTO ogrenci)
        {
            if (!uow.GetRepository<Ogrenci>().GetAll().Any(z=>z.Adi == ogrenci.Adi))
            {
                var eklenen = MapperFactory.CurrentMapper.Map<Ogrenci>(ogrenci);
                uow.GetRepository<Ogrenci>().Add(eklenen);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<OgrenciDTO>(eklenen);
            }
            else
                return null;
        }

        public OgrenciDTO updateOgrenci(OgrenciDTO ogrenci)
        {
            var güncel = uow.GetRepository<Ogrenci>().Get(z => z.Id == ogrenci.Id);
            güncel = MapperFactory.CurrentMapper.Map<Ogrenci>(ogrenci);
            uow.GetRepository<Ogrenci>().Update(güncel);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<OgrenciDTO>(güncel);
        }
    }
}
