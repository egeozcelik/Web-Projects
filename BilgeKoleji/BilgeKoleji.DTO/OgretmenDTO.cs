using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BilgeKoleji.DTO
{
    public class OgretmenDTO
    {
        public int Id { get; set; }

        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int Yas { get; set; }
        public string Cinsiyet { get; set; }
        public string TCK { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        public int DersId { get; set; }
        public DersDTO Ders { get; set; }
    }
}
