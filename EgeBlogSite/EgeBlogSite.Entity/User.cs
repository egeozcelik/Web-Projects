using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgeBlogSite.Entity
{
    public class User
    {
        public User()
        {
            Articles = new HashSet<Article>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public string Password { get; set; }
        public virtual ICollection<Article> Articles{ get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}


