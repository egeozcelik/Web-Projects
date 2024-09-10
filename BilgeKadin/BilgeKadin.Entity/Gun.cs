using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeKadin.Entity
{
    public class Gun
    {
        public Gun()
        {
            Seans = new HashSet<Seans>();
        }
        public int Id { get; set; }
        public string Adi { get; set; }
        public virtual ICollection<Seans> Seans { get; set; }

        public override string ToString()
        {
            return Adi;
        }
    }
}
