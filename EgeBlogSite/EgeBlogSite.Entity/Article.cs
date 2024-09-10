using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgeBlogSite.Entity
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
       
        

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User{ get; set; }


        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category{ get; set; }


    }
}
