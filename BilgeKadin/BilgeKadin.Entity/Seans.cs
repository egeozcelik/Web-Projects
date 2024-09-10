using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeKadin.Entity
{
    public class Seans
    {
        public Seans()
        {
            SinifDers = new HashSet<SinifDers>();
            Gunler = new HashSet<Gun>();
        }
        public int Id { get; set; }
        public string Adi { get; set; }
        public ICollection<Gun> Gunler { get; set; }
        public virtual ICollection<SinifDers> SinifDers { get; set; }

        public override string ToString()
        {
            return Adi;
        }
    }
}
