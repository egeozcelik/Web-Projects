﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BloggerSample.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UserDTO> Users { get; set; }

    }
}
