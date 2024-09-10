using ProgrammersBlog.Shared.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Article:EntityBase,IEntity
    {
        public string Title { get; set; }
        public string Content{ get; set; }
        public string Thumbnail { get; set; }//resmin yolunu tutar
        public DateTime Date { get; set; }
        public int ViewsCount { get; set; }
        public int CommentCount { get; set; }
        public string SeoAuthor { get; set; }//Search engine optimization,arama motorlarının daha rahat bir şekilde anlayabilmesine olanak sağlar
        public string SeoDescription { get; set; }
        public string SeoTags { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Comment> Comments{ get; set; }
    }
}
