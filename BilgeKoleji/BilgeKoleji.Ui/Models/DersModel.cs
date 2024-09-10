using BilgeKoleji.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeKoleji.Ui.Models
{
    public class DersModel
    {
        public DersDTO  DersDTO{ get; set; }
        public List<DersDTO> DersDTOs{ get; set; }
        public List<SinifDTO> SinifDTOs{ get; set; }
    }
}
