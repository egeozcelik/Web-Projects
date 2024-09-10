
using EgeBlogSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EgeBlogSite.UI.Models
{
    public class ViewModel
    {
        
        public Article Article { get; set; }
        public List<User> Users { get; set; }
        public List<Category> Categories { get; set; }
    }
}