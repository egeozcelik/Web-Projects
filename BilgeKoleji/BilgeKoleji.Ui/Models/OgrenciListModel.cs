using BilgeKoleji.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeKoleji.Ui.Models
{
    public class OgrenciListModel
    {
        public List<OgrenciDTO> ogrenciDTOs{ get; set; }
        public List<SinifDTO> sinifDTOs { get; set; }

    }
}
