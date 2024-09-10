using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.DTO
{
   public class SinifDTO
    {
        public int Id { get; set; }

        public string Adi { get; set; }
        public virtual ICollection<DersDTO> Dersler { get; set; }
        public virtual ICollection<OgrenciDTO> Ogrenciler { get; set; }
        public int Kontenjan { get; set; }
    }
}
