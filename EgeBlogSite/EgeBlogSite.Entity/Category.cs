﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgeBlogSite.Entity
{
    public class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<Article> Articles { get; set; }
        public override string ToString()
        {
            return Name;
        }
      

    }
}
