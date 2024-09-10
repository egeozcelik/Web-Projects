using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.DTO
{
   public class GenelTabloDTO
    {
        public int Id { get; set; }
        public OgrenciDTO Ogrenci { get; set; }

        public virtual ICollection<DersDTO> Dersler { get; set; }
        public virtual ICollection<OgretmenDTO> Ogretmenler { get; set; }
        public virtual ICollection<SinifDTO> Sinilar { get; set; }

    }
}
