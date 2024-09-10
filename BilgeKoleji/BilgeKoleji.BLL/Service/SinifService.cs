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
    public class SinifService : ISinifService
    {
        private readonly IUnitOfWork uow;
        public SinifService(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public bool deleteSinif(int SinifId)
        {
            
            try
            {
                var sinif = uow.GetRepository<Sinif>().Get(z => z.Id == SinifId);
                uow.GetRepository<Sinif>().Delete(sinif);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<SinifDTO> getAll()
        {
            List<Sinif> sinifList = new List<Sinif>();
            sinifList = uow.GetRepository<Sinif>().GetAll().ToList();
            List<SinifDTO> siniflistDTO =  MapperFactory.CurrentMapper.Map<List<SinifDTO>>(sinifList);

            return siniflistDTO;

        }

        public SinifDTO getSinif(int sinifId)
        {
            var sinif = uow.GetRepository<Sinif>().Get(z=>z.Id == sinifId);
            return MapperFactory.CurrentMapper.Map<SinifDTO>(sinif);
        }

        public List<SinifDTO> getSinifName(string sinifName)
        {
            var sinifList = uow.GetRepository<Sinif>().Get(z => z.Adi.Contains(sinifName), null).ToList();
            return MapperFactory.CurrentMapper.Map<List<SinifDTO>>(sinifList);
        }

        public SinifDTO newSinif(SinifDTO sinif)
        {
            if (!uow.GetRepository<Sinif>().GetAll().Any(z => z.Adi == sinif.Adi))
            {
                var eklenen = MapperFactory.CurrentMapper.Map<Sinif>(sinif);
                uow.GetRepository<Sinif>().Add(eklenen);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<SinifDTO>(eklenen);
            }
            else
                return null;
        }

        public SinifDTO updateSinif(SinifDTO sinif)
        {
            var güncel = uow.GetRepository<Sinif>().Get(z => z.Id == sinif.Id);
            güncel = MapperFactory.CurrentMapper.Map<Sinif>(sinif);
            uow.GetRepository<Sinif>().Update(güncel);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<SinifDTO>(güncel);
        }
    }
}
