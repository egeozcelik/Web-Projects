using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.DTO
{
    public class DersDTO
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        
        public int SinifId { get; set; }
        public SinifDTO Sinif { get; set; }
        public virtual ICollection<OgretmenDTO> Ogretmenler { get; set; }
    }
}
