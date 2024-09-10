using BilgeKoleji.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BilgeKoleji.Model
{
   public class User : Entity<int>
    {
         public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        [ForeignKey("Role")]
        public Nullable<int> RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
