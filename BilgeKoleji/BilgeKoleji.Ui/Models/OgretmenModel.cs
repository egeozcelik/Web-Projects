using BilgeKoleji.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeKoleji.Ui.Models
{
    public class OgretmenModel
    {
        public OgretmenDTO Ogretmen{ get; set; }
        public List<DersDTO> DersDTOs { get; set; }
    }
}
