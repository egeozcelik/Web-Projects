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
    public class OgretmenService : IOgretmenService
    {
        private readonly IUnitOfWork uow;
        public OgretmenService(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public bool deleteOgretmen(int OgretmenId)
        {
            try
            {
                var ogretmen = uow.GetRepository<Ogretmen>().Get(z => z.Id == OgretmenId);
                uow.GetRepository<Ogretmen>().Delete(ogretmen);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<OgretmenDTO> getAll()
        {
            var ogretmenList = uow.GetRepository<Ogretmen>().GetAll();
            return MapperFactory.CurrentMapper.Map<List<OgretmenDTO>>(ogretmenList);
        }

        public OgretmenDTO getOgretmen(int ogretmenId)
        {
            var ogretmen = uow.GetRepository<Ogretmen>().Get(z => z.Id == ogretmenId);
            return MapperFactory.CurrentMapper.Map<OgretmenDTO>(ogretmen);
        }

        public List<OgretmenDTO> getOgretmenName(string ogretmenName)
        {
            var ogretmenList = uow.GetRepository<Ogretmen>().Get(z => z.Adi.Contains(ogretmenName), null).ToList();
            return MapperFactory.CurrentMapper.Map<List<OgretmenDTO>>(ogretmenList);
        }

        public OgretmenDTO newOgretmen(OgretmenDTO ogretmen)
        {
            if (!uow.GetRepository<Ogretmen>().GetAll().Any(z => z.Adi == ogretmen.Adi))
            {
                var eklenen = MapperFactory.CurrentMapper.Map<Ogretmen>(ogretmen);
                uow.GetRepository<Ogretmen>().Add(eklenen);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<OgretmenDTO>(eklenen);
            }
            else
                return null;
        }

        public OgretmenDTO updateOgretmen(OgretmenDTO ogretmen)
        {
            var güncel = uow.GetRepository<Ogretmen>().Get(z => z.Id == ogretmen.Id);
            güncel = MapperFactory.CurrentMapper.Map<Ogretmen>(ogretmen);
            uow.GetRepository<Ogretmen>().Update(güncel);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<OgretmenDTO>(güncel);
        }
    }
}
