using BilgeKoleji.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.Model
{
    public class Role : Entity<int>
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
