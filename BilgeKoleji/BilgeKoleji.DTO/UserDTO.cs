using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.DTO
{
   public class UserDTO
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }

        public Nullable<int> RoleId { get; set; }

        public RoleDTO roleDTO { get; set; }
    }
}
